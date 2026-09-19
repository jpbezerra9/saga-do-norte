using UnityEngine;
using UnityEngine.UI;

public class ControleDeBarras : MonoBehaviour
{
    [Header("Conexão com os Dados")]
    public UnidadeTatica fichaDoPersonagem;

    [Header("Imagens das Barras")]
    public Image imagemBarraVida;
    public Image imagemBarraEstamina; // No inimigo, vamos deixar isso vazio!

    void Update()
    {
        // O símbolo != significa "Diferente de". A palavra null significa "vazio/nada".
        // Lógica: "SE a imagemBarraVida NÃO estiver vazia, faça a atualização."
        if (imagemBarraVida != null)
        {
            imagemBarraVida.fillAmount = fichaDoPersonagem.vidaAtual / fichaDoPersonagem.VidaMaxima;
        }

        // Lógica: "SE a imagemBarraEstamina NÃO estiver vazia, faça a atualização."
        // Como o Askeladd não terá essa barra, o código ignora e não dá erro!
        if (imagemBarraEstamina != null)
        {
            imagemBarraEstamina.fillAmount = fichaDoPersonagem.estaminaAtual / fichaDoPersonagem.estaminaMaxima;
        }
    }
}