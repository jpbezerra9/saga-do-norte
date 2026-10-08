using UnityEngine;

public class GerenciadorDeProgresso : MonoBehaviour
{
    public static GerenciadorDeProgresso Instancia;

    [Header("Progresso do Jogador")]
    public int nivel = 1;
    public int pontosDisponiveis = 0;

    [Header("Status Base do Thorfinn")]
    public float forcaBase = 10f;
    public float agilidadeBase = 5f;
    public float vidaMaximaBase = 100f;
    public float estaminaMaximaBase = 100f;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GanharNivel(int pontosGanhos)
    {
        nivel++;
        pontosDisponiveis += pontosGanhos;
        Debug.Log("Subiu para o Nível " + nivel + "! Pontos disponíveis: " + pontosDisponiveis);
    }
}