using System.Collections;
using UnityEngine;

public class UnidadeTatica : MonoBehaviour
{
    [Header("Identificação")]
    public string nomePersonagem = "Thorfinn";
    public bool ehJogador = true;

    [Header("Alvo do Combate")]
    public UnidadeTatica alvoAtual;

    [Header("Componentes de Animação e Visual")]
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    [HideInInspector] public Vector3 posicaoInicial;

    [Header("Atributos Base")]
    public float VidaMaxima = 100f;
    public float vidaAtual;

    public float estaminaMaxima = 100f;
    public float estaminaAtual;

    public float forca = 10f;
    public float agilidade = 5f;

    [Header("Estados de Combate")]
    public bool estaDefendendo = false;
    public bool preparouEsquiva = false;
    public bool estaMorto = false;
    public static bool acaoEmAndamento = false;

    public float ChanceDeEsquiva => agilidade * 5f;
    public float ChanceDeCritico => agilidade * 2f;
    public float DanoCritico => forca * 1.5f;
    public float ReducaoDeDanoPassiva => VidaMaxima * 0.001f;

    void Start()
    {
        if (ehJogador && GerenciadorDeProgresso.Instancia != null)
        {
            forca = GerenciadorDeProgresso.Instancia.forcaBase;
            agilidade = GerenciadorDeProgresso.Instancia.agilidadeBase;
            VidaMaxima = GerenciadorDeProgresso.Instancia.vidaMaximaBase;
            estaminaMaxima = GerenciadorDeProgresso.Instancia.estaminaMaximaBase;
        }

        vidaAtual = VidaMaxima;
        estaminaAtual = estaminaMaxima;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        posicaoInicial = transform.position;

        if (anim == null)
        {
            Debug.LogError("ERRO CRÍTICO: Animator não foi encontrado no GameObject " + gameObject.name);
        }
    }

    public void SetSprint(bool valor)
    {
        if (anim == null) return;
        anim.SetBool("isSprinting", valor);
        anim.SetBool("IsSprinting", valor);
    }

    public void TriggerMorte()
    {
        if (anim == null || estaMorto) return;
        estaMorto = true;
        anim.SetBool("isDead", true);
        anim.SetTrigger("Death");
    }

    public void TriggerVitoria()
    {
        if (anim == null) return;
        anim.SetTrigger("Victory");
    }

    public void ReceberAtaque(float danoRecebido, UnidadeTatica atacante)
    {
        StartCoroutine(ProcessarReacaoDano(danoRecebido, atacante));
    }

    private IEnumerator ProcessarReacaoDano(float danoRecebido, UnidadeTatica atacante)
    {
        if (estaMorto) yield break;

        yield return null;

        float chanceFinalEsquiva = preparouEsquiva ? 100f : ChanceDeEsquiva;
        float rolagemEsquiva = Random.Range(0f, 100f);
        preparouEsquiva = false;

        if (rolagemEsquiva <= chanceFinalEsquiva)
        {
            if (anim != null) anim.SetTrigger("Dodge");
            Debug.Log(nomePersonagem + " esquivou do ataque!");

            if (Random.Range(0f, 100f) <= ChanceDeCritico && atacante != null && !atacante.estaMorto)
            {
                StartCoroutine(RotinaContraAtaque(atacante));
            }
            yield break;
        }

        if (estaDefendendo)
        {
            if (anim != null) anim.SetTrigger("Defend");
            danoRecebido *= 0.5f;
            estaDefendendo = false;
        }
        else
        {
            if (anim != null) anim.SetTrigger("Hurt");
            danoRecebido -= ReducaoDeDanoPassiva;
            if (danoRecebido < 1f) danoRecebido = 1f;
            vidaAtual -= danoRecebido;
        }

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            TriggerMorte();
        }
    }

    private IEnumerator RotinaContraAtaque(UnidadeTatica atacante)
    {
        yield return new WaitForSeconds(0.3f);
        if (anim != null) anim.SetTrigger("CounterAttack");

        yield return new WaitForSeconds(0.4f);

        if (atacante != null && !atacante.estaMorto)
        {
            float danoContra = forca * 0.5f;
            atacante.vidaAtual -= danoContra;

            if (atacante.vidaAtual <= 0)
            {
                atacante.vidaAtual = 0;
                atacante.TriggerMorte();
            }
            else
            {
                if (atacante.anim != null) atacante.anim.SetTrigger("Hurt");
            }
        }
        yield return new WaitForSeconds(0.4f);
    }
}