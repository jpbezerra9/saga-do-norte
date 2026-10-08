using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapaEstrategicoManager : MonoBehaviour
{
    [Header("Interface de Status (Canto Superior Direito)")]
    public TextMeshProUGUI textoNivelEPontos;
    public TextMeshProUGUI textoForca;
    public TextMeshProUGUI textoAgilidade;
    public TextMeshProUGUI textoVida;

    [Header("Botões de Upgrade (+1)")]
    public Button btnUparForca;
    public Button btnUparAgilidade;
    public Button btnUparVida;

    [Header("Configuração de Cena")]
    public string nomeDaCenaDeBatalha = "Battle 3";

    void Start()
    {
        AtualizarInterface();
    }

    public void AtualizarInterface()
    {
        if (GerenciadorDeProgresso.Instancia == null) return;

        var prog = GerenciadorDeProgresso.Instancia;

        textoNivelEPontos.text = $"Nível: {prog.nivel} | Pontos: {prog.pontosDisponiveis}";
        textoForca.text = $"Força: {prog.forcaBase}";
        textoAgilidade.text = $"Agilidade: {prog.agilidadeBase}";
        textoVida.text = $"Vida Máx: {prog.vidaMaximaBase}";

        bool temPontos = prog.pontosDisponiveis > 0;
        btnUparForca.interactable = temPontos;
        btnUparAgilidade.interactable = temPontos;
        btnUparVida.interactable = temPontos;
    }

    public void UparForca()
    {
        if (GerenciadorDeProgresso.Instancia.pontosDisponiveis > 0)
        {
            GerenciadorDeProgresso.Instancia.forcaBase += 2f;
            GerenciadorDeProgresso.Instancia.pontosDisponiveis--;
            AtualizarInterface();
        }
    }

    public void UparAgilidade()
    {
        if (GerenciadorDeProgresso.Instancia.pontosDisponiveis > 0)
        {
            GerenciadorDeProgresso.Instancia.agilidadeBase += 1f;
            GerenciadorDeProgresso.Instancia.pontosDisponiveis--;
            AtualizarInterface();
        }
    }

    public void UparVida()
    {
        if (GerenciadorDeProgresso.Instancia.pontosDisponiveis > 0)
        {
            GerenciadorDeProgresso.Instancia.vidaMaximaBase += 15f;
            GerenciadorDeProgresso.Instancia.pontosDisponiveis--;
            AtualizarInterface();
        }
    }

    public void IniciarBatalhaNovamente()
    {
        SceneManager.LoadScene(nomeDaCenaDeBatalha);
    }
}