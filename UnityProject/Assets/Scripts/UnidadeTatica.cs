using System.Collections;
using UnityEngine;

// Ficha de RPG do personagem (Thorfinn, Thors, Askeladd, etc.)
public class UnidadeTatica : MonoBehaviour
{
    [Header("Identificação")]
    public string nomePersonagem;

    [Header("Alvo do Combate")]
    public Transform alvoAtual; // Arraste o GameObject do Inimigo/Player aqui!

    [Header("Componentes de Animação")]
    public Animator anim;
    private Vector3 posicaoInicial;
    private SpriteRenderer spriteRenderer;

    [Header("Atributos Base")]
    public float VidaMaxima = 100f;
    public float vidaAtual;
    
    public float estaminaMaxima = 100f;
    public float estaminaAtual;
    
    public float forca = 10f;
    public float agilidade = 5f;

    [Header("Estados de Combate (Memória)")]
    public bool estaDefendendo = false;
    public bool preparouEsquiva = false; 
    public static bool acaoEmAndamento = false; // Trava global para impedir que ações se sobreponham

    // --- Atributos Dinâmicos ---
    public float ChanceDeEsquiva { get { return agilidade * 5f; } }
    public float ChanceDeCritico { get { return agilidade * 2f; } }
    public float DanoCritico { get { return forca * 1.5f; } }
    public float ReducaoDeDanoPassiva { get { return VidaMaxima * 0.001f; } }

    void Start()
    {
        vidaAtual = VidaMaxima;
        estaminaAtual = estaminaMaxima;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        posicaoInicial = transform.position;

        if (anim == null)
        {
            Debug.LogError("ERRO CRÍTICO: O Animator não está atribuído no GameObject " + gameObject.name);
        }
    }

    // ==========================================
    // AÇÕES DOS BOTÕES DA UI (O SEU TURNO)
    // ==========================================

    public void BotaoAtaqueLeve()
    {
        if (acaoEmAndamento) return; // Bloqueia se já houver uma animação rodando
        
        estaDefendendo = false;
        preparouEsquiva = false;
        
        float danoFinal = forca;
        if (Random.Range(0f, 100f) <= ChanceDeCritico) danoFinal = DanoCritico;

        StartCoroutine(RotinaDeAtaque(alvoAtual, "LightAttack", danoFinal));
    }

    public void BotaoAtaquePesado()
    {
        if (acaoEmAndamento) return;

        estaDefendendo = false;
        preparouEsquiva = false;
        
        float danoFinal = forca * 1.3f; 
        if (Random.Range(0f, 100f) <= ChanceDeCritico) danoFinal = DanoCritico * 1.3f;

        StartCoroutine(RotinaDeAtaque(alvoAtual, "HeavyAttack", danoFinal));
    }

    public void BotaoDefesa()
    {
        if (acaoEmAndamento) return;

        estaDefendendo = true;
        preparouEsquiva = false;
        Debug.Log(nomePersonagem + " entrou em postura de defesa.");
    }

    public void BotaoEsquiva()
    {
        if (acaoEmAndamento) return;

        preparouEsquiva = true; 
        estaDefendendo = false;
        Debug.Log(nomePersonagem + " focou na esquiva para o próximo turno.");
    }

    // ==========================================
    // MOVIMENTAÇÃO E ANIMAÇÃO (CORROTINA)
    // ==========================================
    private IEnumerator RotinaDeAtaque(Transform alvo, string triggerAtaque, float danoCalculado)
    {
        if (alvo == null) yield break;

        acaoEmAndamento = true; // Trava as ações enquanto executa o ataque completo

        // 1. Inicia o Sprint e corre até o inimigo
        if (anim != null) anim.SetBool("isSprinting", true);
        
        float direcao = (alvo.position.x > transform.position.x) ? -1.5f : 1.5f;
        Vector3 posicaoAlvo = new Vector3(alvo.position.x + direcao, alvo.position.y, alvo.position.z); 
        
        while (Vector3.Distance(transform.position, posicaoAlvo) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicaoAlvo, 7f * Time.deltaTime);
            yield return null;
        }

        // 2. Chegou no inimigo. Para o sprint e aciona o ataque
        if (anim != null) anim.SetBool("isSprinting", false);
        
        if (anim != null && anim.runtimeAnimatorController != null)
        {
            anim.SetTrigger(triggerAtaque);
        }

        // Aguarda a animação de ataque dar o golpe visual
        yield return new WaitForSeconds(0.3f);

        // 3. Aplica o dano no alvo
        Debug.Log(nomePersonagem + " tentou bater em: " + alvo.name);
        
        UnidadeTatica statusAlvo = alvo.GetComponent<UnidadeTatica>();
        if (statusAlvo != null)
        {
            statusAlvo.ReceberAtaque(danoCalculado);
        }

        // Tempo de permanência no alvo após golpear
        yield return new WaitForSeconds(0.7f);

        // 4. Inicia o Sprint e volta para a posição inicial de costas
        if (anim != null) anim.SetBool("isSprinting", true);
        if (spriteRenderer != null) spriteRenderer.flipX = true; 

        while (Vector3.Distance(transform.position, posicaoInicial) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicaoInicial, 7f * Time.deltaTime);
            yield return null;
        }

        // 5. Chegou na base. Volta pro Idle.
        if (anim != null) anim.SetBool("isSprinting", false);
        if (spriteRenderer != null) spriteRenderer.flipX = false; 

        acaoEmAndamento = false; // Libera o turno para novas ações ou contra-ataques
    }

    // ==========================================
    // REAÇÕES (QUANDO ESTA UNIDADE TOMA DANO)
    // ==========================================
    public void ReceberAtaque(float danoRecebido)
    {
        StartCoroutine(ProcessarReacaoDano(danoRecebido));
    }

    private IEnumerator ProcessarReacaoDano(float danoRecebido)
    {
        if (vidaAtual <= 0) yield break;

        yield return null; 

        float chanceFinalEsquiva = preparouEsquiva ? 100f : ChanceDeEsquiva;
        float rolagemEsquiva = Random.Range(0f, 100f);
        preparouEsquiva = false; 

        // 1. Checagem de Esquiva 
        if (rolagemEsquiva <= chanceFinalEsquiva)
        {
            if (anim != null) anim.SetTrigger("Dodge");
            Debug.Log(nomePersonagem + " -> Acionou TRIGGER: Dodge");

            if (Random.Range(0f, 100f) <= ChanceDeCritico) 
            {
                StartCoroutine(RotinaContraAtaque());
            }
            yield break; 
        }

        // 2. Checagem de Defesa 
        if (estaDefendendo)
        {
            if (anim != null) anim.SetTrigger("Defend");
            Debug.Log(nomePersonagem + " -> Acionou TRIGGER: Defend");
            danoRecebido = danoRecebido * 0.5f; 
            estaDefendendo = false; 
        }
        else
        {
            // 3. Acerto Direto (Hurt)
            if (anim != null) anim.SetTrigger("Hurt");
            Debug.Log(nomePersonagem + " -> Acionou TRIGGER: Hurt no Animator!");

            danoRecebido -= ReducaoDeDanoPassiva;
            if (danoRecebido < 1f) danoRecebido = 1f; 

            vidaAtual -= danoRecebido;
            Debug.Log(nomePersonagem + " recebeu " + danoRecebido + " de dano. Vida restante: " + vidaAtual);
        }

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            if (anim != null) anim.SetBool("isDead", true);
            Debug.Log(nomePersonagem + " MORREU!");
        }
    }

    // ==========================================
    // CORROTINA DE CONTRA-ATAQUE
    // ==========================================
    private IEnumerator RotinaContraAtaque()
    {
        acaoEmAndamento = true;
        yield return new WaitForSeconds(0.6f); 
        if (anim != null) anim.SetTrigger("CounterAttack");
        Debug.Log(nomePersonagem + " -> Acionou TRIGGER: CounterAttack");
        yield return new WaitForSeconds(0.5f);
        acaoEmAndamento = false;
    }
}