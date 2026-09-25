using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;
using UnityEngine.Video; // NOVA BIBLIOTECA: Permite que o código controle Video Players

public class SistemaDeCombate : MonoBehaviour
{
    public enum EstadoTurno { TurnoDoJogador, TurnoDoInimigo, FimDeBatalha }
    
    [Header("Gerenciamento de Turno")]
    public EstadoTurno estadoAtual;
    public CanvasGroup painelDeAcoes; 

    [Header("Participantes do Combate")]
    public UnidadeTatica jogador;
    public UnidadeTatica inimigo;

    [Header("Feedback Visual")]
    public GameObject prefabTextoFlutuante; 

    [Header("Final Alternativo (Vitória)")]
    public CanvasGroup telaFalsoFinalFeliz; 
    public AudioSource tocadorDeMusica; 
    // NOVA VARIÁVEL: Referência ao aparelho de DVD invisível que criamos
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

    // ==========================================
    // AÇÕES DO JOGADOR
    // ==========================================

    public void AcaoAtaqueLeve()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador) return;

        float danoFinal = jogador.forca;
        bool critico = false;
        
        if (Random.Range(1f, 101f) <= jogador.ChanceDeCritico)
        {
            danoFinal = jogador.DanoCritico;
            critico = true;
        }

        AplicarDano(inimigo, jogador, danoFinal, critico);
        PassarTurnoParaInimigo();
    }

    public void AcaoAtaquePesado()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador) return;

        if (jogador.estaminaAtual >= 20f)
        {
            jogador.estaminaAtual -= 20f;
            float danoFinal = jogador.forca + (jogador.forca * 0.30f);
            
            AplicarDano(inimigo, jogador, danoFinal, false);
            PassarTurnoParaInimigo();
        }
        else
        {
            GerarTextoFlutuante(jogador, "Sem Estamina!", Color.yellow);
        }
    }

    public void AcaoDefesa()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador) return;

        jogador.estaDefendendo = true;
        GerarTextoFlutuante(jogador, "Defesa Armada!", Color.green);
        PassarTurnoParaInimigo();
    }

    public void AcaoEsquiva()
    {
        if (estadoAtual != EstadoTurno.TurnoDoJogador) return;

        if (jogador.estaminaAtual >= 15f)
        {
            jogador.estaminaAtual -= 15f;
            
            if (Random.Range(1f, 101f) <= jogador.ChanceDeEsquiva)
            {
                jogador.preparouEsquiva = true; 
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

    // ==========================================
    // LÓGICA DE TURNOS E INTELIGÊNCIA ARTIFICIAL
    // ==========================================

    private void PassarTurnoParaInimigo()
    {
        if (estadoAtual == EstadoTurno.FimDeBatalha) return;

        estadoAtual = EstadoTurno.TurnoDoInimigo;
        painelDeAcoes.interactable = false; 

        StartCoroutine(TurnoDoInimigoIA());
    }

    private IEnumerator TurnoDoInimigoIA()
    {
        yield return new WaitForSeconds(1.5f);

        int escolhaIA = Random.Range(1, 5);

        if (escolhaIA == 2 && inimigo.estaminaAtual < 20f) escolhaIA = 1; 
        if (escolhaIA == 4 && inimigo.estaminaAtual < 15f) escolhaIA = 3; 

        switch (escolhaIA)
        {
            case 1: 
                float danoLeve = inimigo.forca;
                bool criticoLeve = false;
                if (Random.Range(1f, 101f) <= inimigo.ChanceDeCritico)
                {
                    danoLeve = inimigo.DanoCritico;
                    criticoLeve = true;
                }
                AplicarDano(jogador, inimigo, danoLeve, criticoLeve);
                break;

            case 2: 
                inimigo.estaminaAtual -= 20f;
                float danoPesado = inimigo.forca + (inimigo.forca * 0.30f);
                AplicarDano(jogador, inimigo, danoPesado, false);
                break;

            case 3: 
                inimigo.estaDefendendo = true;
                GerarTextoFlutuante(inimigo, "Defesa Armada!", Color.green);
                break;

            case 4: 
                inimigo.estaminaAtual -= 15f;
                if (Random.Range(1f, 101f) <= inimigo.ChanceDeEsquiva)
                {
                    inimigo.preparouEsquiva = true;
                    GerarTextoFlutuante(inimigo, "Esquiva Pronta!", Color.blue);
                }
                else
                {
                    inimigo.preparouEsquiva = false;
                    GerarTextoFlutuante(inimigo, "Falhou...", Color.gray);
                }
                break;
        }

        if (estadoAtual != EstadoTurno.FimDeBatalha)
        {
            estadoAtual = EstadoTurno.TurnoDoJogador;
            painelDeAcoes.interactable = true; 
        }
    }

    // ==========================================
    // MOTOR DE DANO E CONSEQUÊNCIAS
    // ==========================================

    private void AplicarDano(UnidadeTatica alvo, UnidadeTatica atacante, float danoBruto, bool foiCritico = false)
    {
        if (alvo.preparouEsquiva)
        {
            alvo.preparouEsquiva = false; 
            
            float danoContra = alvo.forca * 0.5f; 
            bool contraCritico = false;

            if (Random.Range(1f, 101f) <= alvo.ChanceDeCritico)
            {
                danoContra = alvo.DanoCritico * 0.5f; 
                contraCritico = true;
            }

            danoContra = Mathf.Round(danoContra);
            atacante.vidaAtual -= danoContra;
            
            GerarTextoFlutuante(alvo, "Esquivou!", Color.cyan);

            if (contraCritico)
            {
                GerarTextoFlutuante(atacante, "Contra Crítico!\n" + danoContra, Color.red);
            }
            else
            {
                GerarTextoFlutuante(atacante, "Contra-Ataque!\n" + danoContra, Color.magenta);
            }
            
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
        }
        else if (foiCritico)
        {
            corDoTexto = Color.red; 
            mensagemDano = "Crítico!\n";
        }

        danoReal = danoReal - (danoReal * alvo.ReducaoDeDanoPassiva);
        danoReal = Mathf.Round(danoReal); 
        
        alvo.vidaAtual -= danoReal;
        alvo.estaDefendendo = false; 

        mensagemDano += danoReal.ToString();
        GerarTextoFlutuante(alvo, mensagemDano, corDoTexto);
        
        VerificarMorte(alvo);
    }

    // ==========================================
    // FINAIS DA BATALHA
    // ==========================================

    private void VerificarMorte(UnidadeTatica unidade)
    {
        if (unidade.vidaAtual <= 0)
        {
            unidade.vidaAtual = 0;
            estadoAtual = EstadoTurno.FimDeBatalha; 
            painelDeAcoes.interactable = false; 

            if (unidade.nomePersonagem == "Askeladd")
            {
                Debug.Log("VITÓRIA! Iniciando Falso Final Feliz...");
                StartCoroutine(RotinaFalsoFinalFeliz());
            }
            else
            {
                Debug.Log("DERROTA! Thors caiu. Seguindo para o Mapa Estratégico...");
                Invoke("CarregarMapaEstrategico", 2f);
            }
        }
    }

    private void CarregarMapaEstrategico()
    {
        SceneManager.LoadScene("MapaEstrategico");
    }

    private IEnumerator RotinaFalsoFinalFeliz()
    {
        if (tocadorDeMusica != null) tocadorDeMusica.Play();
        
        // NOVO: Dá o play no vídeo apenas agora que o inimigo foi derrotado
        if (videoFinalFeliz != null) videoFinalFeliz.Play();

        while (telaFalsoFinalFeliz.alpha < 1f)
        {
            telaFalsoFinalFeliz.alpha += velocidadeDeTransicao * Time.deltaTime;
            yield return null; 
        }

        telaFalsoFinalFeliz.alpha = 1f;
        telaFalsoFinalFeliz.blocksRaycasts = true;
    }

    private void GerarTextoFlutuante(UnidadeTatica alvo, string mensagem, Color cor)
    {
        if (prefabTextoFlutuante == null) return; 

        Vector3 posicaoTexto = alvo.transform.position + new Vector3(0, 1.5f, 0);
        GameObject novoTexto = Instantiate(prefabTextoFlutuante, posicaoTexto, Quaternion.identity);
        novoTexto.GetComponent<TextoFlutuante>().ConfigurarTexto(mensagem, cor);
    }
}