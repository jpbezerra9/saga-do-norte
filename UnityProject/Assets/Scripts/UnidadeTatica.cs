using UnityEngine;

public class UnidadeTatica : MonoBehaviour
{
    [Header("Informações Básicas")]
    public string nomePersonagem;
    public int nivel = 1;
    public int pontosEmVida = 0; // Os pontos que o jogador distribui ao upar

    [Header("Atributos Base")]
    public float vidaBase = 100f;
    public float vidaAtual;
    public float estaminaMaxima = 100f;
    public float estaminaAtual;
    public float forca = 10f;
    public float agilidade = 5f;

    // Fórmulas Matemáticas (O símbolo => significa "Calcule isto agora")
    
    // Vida Maxima = Base (100) + (Base * (Pontos * 10%))
    public float VidaMaxima => vidaBase + (vidaBase * (pontosEmVida * 0.10f));
    
    // Redução passiva de dano: 10% (0.10) para cada ponto em Vida
    public float ReducaoDeDanoPassiva => pontosEmVida * 0.10f; 

    // Esquiva: 10% base + 5% por ponto de Agilidade
    public float ChanceDeEsquiva => 10f + (agilidade * 5f); 
    
    // Crítico e Contra-Ataque: 5% base + 1% por ponto de Agilidade
    public float ChanceDeCritico => 5f + (agilidade * 1f);
    public float ChanceDeContraAtaque => 5f + (agilidade * 1f);
    
    // Dano Crítico = (Força * 2) + 10% da força multiplicada por cada ponto
    public float DanoCritico => (forca * 2f) + (forca * 0.10f * forca);

    public bool estaDefendendo = false; // Avisa se o botão de defesa foi apertado neste turno

    void Start()
    {
        // Ao iniciar, a vida e estamina enchem baseadas nas fórmulas acima
        vidaAtual = VidaMaxima;
        estaminaAtual = estaminaMaxima;
    }
}