using UnityEngine;
using UnityEngine.SceneManagement; // Biblioteca obrigatória para trocar de cenas

public class GerenciadorDeMenu : MonoBehaviour
{
    // Função chamada ao clicar no botão Começar
    public void IniciarJogo()
    {
        Debug.Log("Iniciando o Prólogo...");
        // Carrega exatamente o nome da cena do Prólogo
        SceneManager.LoadScene("Prologo_Batalha");
    }

    // Função chamada ao clicar no botão Sair
    public void SairDoJogo()
    {
        Debug.Log("Fechando o jogo...");
        // Application.Quit fecha o jogo na versão final. No Editor da Unity, não tem efeito visual.
        Application.Quit();
    }
}