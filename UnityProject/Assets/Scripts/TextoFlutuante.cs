using UnityEngine;
using TMPro; // Biblioteca obrigatória para controlar o TextMeshPro

public class TextoFlutuante : MonoBehaviour
{
    // Velocidade com que o texto sobe na tela
    public float velocidadeSubida = 1.5f;
    // Tempo em segundos até o texto sumir
    public float tempoDeVida = 1.0f; 
    
    // Referência ao componente de texto para podermos mudar a cor e o conteúdo
    private TextMeshPro textoMesh;
    private Color corOriginal;

    void Awake()
    {
        // Awake acontece antes do Start. Aqui "pegamos" o componente de texto do objeto
        textoMesh = GetComponent<TextMeshPro>();
    }

    public void ConfigurarTexto(string mensagem, Color cor)
    {
        // Esta função será chamada pelo SistemaDeCombate para definir o que está escrito
        textoMesh.text = mensagem;
        textoMesh.color = cor;
        corOriginal = cor;
        
        // Programa a destruição deste objeto após o tempoDeVida acabar
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // A cada frame do jogo, movemos o texto para cima (eixo Y)
        transform.Translate(Vector3.up * velocidadeSubida * Time.deltaTime);

        // Lógica para fazer o texto ir ficando transparente (Fade Out)
        // Reduzimos a transparência (Alpha) gradativamente com base no tempo
        corOriginal.a -= (Time.deltaTime / tempoDeVida);
        textoMesh.color = corOriginal;
    }
}