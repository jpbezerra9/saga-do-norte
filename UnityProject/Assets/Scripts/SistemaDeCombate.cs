using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class SistemaDeCombate : MonoBehaviour
{
    public enum EstadoTurno { TurnoDoJogador, TurnoDoInimigo, FimDeBatalha }

    [Header("Gerenciamento de Turno")]
    public EstadoTurno estadoAtual;
    public CanvasGroup painelDeAcoes;

    [Header("Áudio Ambiente")]
    public AudioSource musicaDeBatalha; // NOVO: Referência para a música de fundo

    [Header("Participantes do Combate")]
    public UnidadeTatica jogador;
    public UnidadeTatica inimigo;

    [Header("Feedback Visual")]
    public GameObject prefabTextoFlutuante;

    [Header("Final Alternativo (Vitória)")]
    public CanvasGroup telaFalsoFinalFeliz;
    public AudioSource tocadorDeMusica;
    public VideoPlayer videoFinalFeliz;
    public float velocidadeDeTransicao = 0.5f;

    void Start()
    {
        estadoAtual = EstadoTurno.TurnoDoJogador;

        if (telaFalsoFinalFeliz != null)
        {
            telaFalsoFinalFeliz.alpha = 0f;
            telaFalsoFinalFeliz.blocksRaycasts = false;
        }
    }

    private void SetSprint(UnidadeTatica unidade, bool valor)
    {
        if (unidade == null || unidade.anim == null) return;

        unidade.anim.SetBool("isSprinting", valor);
        unidade.anim.SetBool("IsSprinting", valor);

        if (valor)
        {
            unidade.anim.SetTrigger("Sprint");
            unidade.anim.SetTrigger("sprint");
        }
    }

    public void AcaoAtaqueLeve()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador || UnidadeTatica.acaoEmAndamento) return;

        float danoFinal = jogador.forca;
        bool critico = (Random.Range(1f, 101f) <= jogador.ChanceDeCritico);
        if (critico) danoFinal = jogador.DanoCritico;

        StartCoroutine(ExecutarAtaqueComMovimento(jogador, inimigo, "LightAttack", danoFinal, critico));
    }

    public void AcaoAtaquePesado()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador || UnidadeTatica.acaoEmAndamento) return;

        if (jogador.estaminaAtual >= 20f)
        {
            jogador.estaminaAtual -= 20f;
            float danoFinal = jogador.forca + (jogador.forca * 0.30f);

            StartCoroutine(ExecutarAtaqueComMovimento(jogador, inimigo, "HeavyAttack", danoFinal, false));
        }
        else
        {
            GerarTextoFlutuante(jogador, "Sem Estamina!", Color.yellow);
        }
    }

    public void AcaoDefesa()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador || UnidadeTatica.acaoEmAndamento) return;

        jogador.estaDefendendo = true;
        if (jogador.anim != null) jogador.anim.SetTrigger("Defend");
        GerarTextoFlutuante(jogador, "Defesa Armada!", Color.green);

        PassarTurnoParaInimigo();
    }

    public void AcaoEsquiva()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador || UnidadeTatica.acaoEmAndamento) return;

        if (jogador.estaminaAtual >= 15f)
        {
            jogador.estaminaAtual -= 15f;

            if (Random.Range(1f, 101f) <= jogador.ChanceDeEsquiva)
            {
                jogador.preparouEsquiva = true;
                if (jogador.anim != null) jogador.anim.SetTrigger("Dodge");
                GerarTextoFlutuante(jogador, "Esquiva Pronta!", Color.blue);
            }
            else
            {
                jogador.preparouEsquiva = false;
                GerarTextoFlutuante(jogador, "Falhou...", Color.gray);
            }
            PassarTurnoParaInimigo();
        }
        else
        {
            GerarTextoFlutuante(jogador, "Sem Estamina!", Color.yellow);
        }
    }

    private IEnumerator ExecutarAtaqueComMovimento(UnidadeTatica atacante, UnidadeTatica defensor, string triggerAtaque, float dano, bool critico)
    {
        UnidadeTatica.acaoEmAndamento = true;
        SpriteRenderer sr = atacante.GetComponent<SpriteRenderer>();
        Vector3 posOrigem = atacante.posicaoInicial;

        SetSprint(atacante, true);
        yield return null;

        float direcaoAteAlvo = (defensor.transform.position.x > atacante.transform.position.x) ? -1.8f : 1.8f;
        Vector3 posDestino = new Vector3(defensor.transform.position.x + direcaoAteAlvo, atacante.transform.position.y, atacante.transform.position.z);

        while (Mathf.Abs(atacante.transform.position.x - posDestino.x) > 0.08f)
        {
            atacante.transform.position = Vector3.MoveTowards(atacante.transform.position, posDestino, 7f * Time.deltaTime);
            yield return null;
        }

        atacante.transform.position = posDestino;

        if (atacante.anim != null) atacante.anim.SetTrigger(triggerAtaque);
        yield return new WaitForSeconds(0.1f);
        SetSprint(atacante, false);

        yield return new WaitForSeconds(0.35f);

        AplicarDano(defensor, atacante, dano, critico);

        yield return new WaitForSeconds(0.5f);

        if (defensor.vidaAtual > 0 && atacante.vidaAtual > 0 && estadoAtual != EstadoTurno.FimDeBatalha)
        {
            SetSprint(atacante, true);

            if (sr != null)
            {
                sr.flipX = (atacante.transform.position.x < posOrigem.x);
            }

            while (Mathf.Abs(atacante.transform.position.x - posOrigem.x) > 0.08f)
            {
                atacante.transform.position = Vector3.MoveTowards(atacante.transform.position, posOrigem, 7f * Time.deltaTime);
                yield return null;
            }

            atacante.transform.position = posOrigem;
            SetSprint(atacante, false);
            if (sr != null) sr.flipX = false;
        }
        else
        {
            SetSprint(atacante, false);
            if (sr != null) sr.flipX = false;
        }

        UnidadeTatica.acaoEmAndamento = false;

        if (atacante == jogador && estadoAtual != EstadoTurno.FimDeBatalha)
        {
            PassarTurnoParaInimigo();
        }
    }

    private void PassarTurnoParaInimigo()
    {
        if (estadoAtual == EstadoTurno.FimDeBatalha) return;

        estadoAtual = EstadoTurno.TurnoDoInimigo;
        if (painelDeAcoes != null) painelDeAcoes.interactable = false;

        StartCoroutine(TurnoDoInimigoIA());
    }

    private IEnumerator TurnoDoInimigoIA()
    {
        yield return new WaitForSeconds(0.8f);

        int rolagem = Random.Range(1, 101);
        int escolhaIA;

        if (rolagem <= 45) escolhaIA = 1;
        else if (rolagem <= 80) escolhaIA = 2;
        else if (rolagem <= 90) escolhaIA = 3;
        else escolhaIA = 4;

        if (escolhaIA == 2 && inimigo.estaminaAtual < 20f) escolhaIA = 1;
        if (escolhaIA == 4 && inimigo.estaminaAtual < 15f) escolhaIA = 1;

        switch (escolhaIA)
        {
            case 1:
                float danoLeve = inimigo.forca;
                bool criticoLeve = (Random.Range(1f, 101f) <= inimigo.ChanceDeCritico);
                if (criticoLeve) danoLeve = inimigo.DanoCritico;
                yield return StartCoroutine(ExecutarAtaqueComMovimento(inimigo, jogador, "LightAttack", danoLeve, criticoLeve));
                break;

            case 2:
                inimigo.estaminaAtual -= 20f;
                float danoPesado = inimigo.forca + (inimigo.forca * 0.30f);
                yield return StartCoroutine(ExecutarAtaqueComMovimento(inimigo, jogador, "HeavyAttack", danoPesado, false));
                break;

            case 3:
                inimigo.estaDefendendo = true;
                if (inimigo.anim != null) inimigo.anim.SetTrigger("Defend");
                GerarTextoFlutuante(inimigo, "Defesa Armada!", Color.green);
                yield return new WaitForSeconds(0.8f);
                break;

            case 4:
                inimigo.estaminaAtual -= 15f;
                if (Random.Range(1f, 101f) <= inimigo.ChanceDeEsquiva)
                {
                    inimigo.preparouEsquiva = true;
                    if (inimigo.anim != null) inimigo.anim.SetTrigger("Dodge");
                    GerarTextoFlutuante(inimigo, "Esquiva Pronta!", Color.blue);
                }
                else
                {
                    inimigo.preparouEsquiva = false;
                    GerarTextoFlutuante(inimigo, "Falhou...", Color.gray);
                }
                yield return new WaitForSeconds(0.8f);
                break;
        }

        if (estadoAtual != EstadoTurno.FimDeBatalha)
        {
            estadoAtual = EstadoTurno.TurnoDoJogador;
            if (painelDeAcoes != null) painelDeAcoes.interactable = true;
        }
    }

    private void AplicarDano(UnidadeTatica alvo, UnidadeTatica atacante, float danoBruto, bool foiCritico = false)
    {
        if (estadoAtual == EstadoTurno.FimDeBatalha) return;

        if (alvo.preparouEsquiva)
        {
            alvo.preparouEsquiva = false;
            if (alvo.anim != null) alvo.anim.SetTrigger("Dodge");

            float danoContra = alvo.forca * 0.5f;
            bool contraCritico = (Random.Range(1f, 101f) <= alvo.ChanceDeCritico);
            if (contraCritico) danoContra = alvo.DanoCritico * 0.5f;

            danoContra = Mathf.Round(danoContra);
            atacante.vidaAtual -= danoContra;

            if (alvo.anim != null) alvo.anim.SetTrigger("CounterAttack");
            if (atacante.anim != null) atacante.anim.SetTrigger("Hurt");

            GerarTextoFlutuante(alvo, "Esquivou!", Color.cyan);
            GerarTextoFlutuante(atacante, "Contra-Ataque!\n" + danoContra, Color.magenta);

            VerificarMorte(atacante);
            return;
        }

        float danoReal = danoBruto;
        string mensagemDano = "";
        Color corDoTexto = Color.white;

        if (alvo.estaDefendendo)
        {
            danoReal = danoBruto - (danoBruto * 0.20f);
            mensagemDano = "Defendido!\n";
            corDoTexto = Color.cyan;
            if (alvo.anim != null) alvo.anim.SetTrigger("Defend");
        }
        else
        {
            if (foiCritico)
            {
                corDoTexto = Color.red;
                mensagemDano = "Crítico!\n";
            }
            if (alvo.anim != null) alvo.anim.SetTrigger("Hurt");
        }

        danoReal = danoReal - (danoReal * alvo.ReducaoDeDanoPassiva);
        danoReal = Mathf.Round(danoReal);

        alvo.vidaAtual -= danoReal;
        alvo.estaDefendendo = false;

        mensagemDano += danoReal.ToString();
        GerarTextoFlutuante(alvo, mensagemDano, corDoTexto);

        VerificarMorte(alvo);
    }

    private void VerificarMorte(UnidadeTatica unidade)
    {
        if (estadoAtual == EstadoTurno.FimDeBatalha) return;

        if (unidade.vidaAtual <= 0)
        {
            unidade.vidaAtual = 0;
            estadoAtual = EstadoTurno.FimDeBatalha;
            if (musicaDeBatalha != null) musicaDeBatalha.Stop();
            if (painelDeAcoes != null) painelDeAcoes.interactable = false;

            UnidadeTatica vencedor = (unidade == jogador) ? inimigo : jogador;

            if (unidade.anim != null)
            {
                unidade.anim.SetBool("isDead", true);
                unidade.anim.SetTrigger("Death");
            }

            if (vencedor != null && vencedor.anim != null)
            {
                vencedor.anim.SetTrigger("Victory");
            }

            if (unidade == inimigo)
            {
                Debug.Log("VITÓRIA DO JOGADOR! Executando Falso Final Feliz...");
                StartCoroutine(RotinaFalsoFinalFeliz());
            }
            else
            {
                Debug.Log("DERROTA DO JOGADOR! Subindo de nível e indo para o Mapa Estratégico...");

                // NOVO: Dá os pontos para ser usado no Mapa Estratégico
                if (GerenciadorDeProgresso.Instancia != null)
                {
                    GerenciadorDeProgresso.Instancia.GanharNivel(1);
                }

                Invoke("CarregarMapaEstrategico", 3.5f);
            }
        }
    }

    private void CarregarMapaEstrategico()
    {
        SceneManager.LoadScene("MapaEstrategico");
    }

    private IEnumerator RotinaFalsoFinalFeliz()
    {
        yield return new WaitForSeconds(1.5f);

        if (tocadorDeMusica != null) tocadorDeMusica.Play();
        if (videoFinalFeliz != null) videoFinalFeliz.Play();

        while (telaFalsoFinalFeliz != null && telaFalsoFinalFeliz.alpha < 1f)
        {
            telaFalsoFinalFeliz.alpha += velocidadeDeTransicao * Time.deltaTime;
            yield return null;
        }

        if (telaFalsoFinalFeliz != null)
        {
            telaFalsoFinalFeliz.alpha = 1f;
            telaFalsoFinalFeliz.blocksRaycasts = true;
        }
    }

    private void GerarTextoFlutuante(UnidadeTatica alvo, string mensagem, Color cor)
    {
        if (prefabTextoFlutuante == null || alvo == null) return;

        Vector3 posicaoTexto = alvo.transform.position + new Vector3(0, 1.5f, 0);
        GameObject novoTexto = Instantiate(prefabTextoFlutuante, posicaoTexto, Quaternion.identity);

        TextoFlutuante tf = novoTexto.GetComponent<TextoFlutuante>();
        if (tf != null)
        {
            tf.ConfigurarTexto(mensagem, cor);
        }
    }
}