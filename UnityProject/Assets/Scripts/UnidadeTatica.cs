using UnityEngine;

// Ficha de RPG do personagem (Thorfinn, Thors, Askeladd, etc.)
public class UnidadeTatica : MonoBehaviour
{
    [Header("Identificação")]
    public string nomePersonagem;

    [Header("Atributos Base")]
    public float VidaMaxima = 100f;
    public float vidaAtual;
    
    public float estaminaMaxima = 100f;
    public float estaminaAtual;
    
    public float forca = 10f;
    public float agilidade = 5f;

    [Header("Estados de Combate (Memória)")]
    // Guarda se o personagem clicou no botão de defesa neste turno
    public bool estaDefendendo = false;
    
    // Guarda se a esquiva foi ativada com sucesso para rolar o contra-ataque
    public bool preparouEsquiva = false; 

    // --- Atributos Dinâmicos calculados a partir dos atributos base ---
    
    // 5% de chance de esquiva para cada ponto de Agilidade
    public float ChanceDeEsquiva { get { return agilidade * 5f; } }
    
    // 2% de chance de crítico para cada ponto de Agilidade
    public float ChanceDeCritico { get { return agilidade * 2f; } }
    
    // O Crítico causa o dano da Força + 50% de bônus
    public float DanoCritico { get { return forca * 1.5f; } }
    
    // Quanto mais Vida Máxima, mais armadura natural o personagem tem
    public float ReducaoDeDanoPassiva { get { return VidaMaxima * 0.001f; } }

    void Start()
    {
        vidaAtual = VidaMaxima;
        estaminaAtual = estaminaMaxima;
    }
}