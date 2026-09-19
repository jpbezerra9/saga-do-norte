using UnityEngine;

public class SistemaDeCombate : MonoBehaviour
{
    [Header("Participantes do Combate")]
    public UnidadeTatica jogador;
    public UnidadeTatica inimigo;

    public void AcaoAtaqueLeve()
    {
        float danoFinal = jogador.forca; // Dano base do ataque leve
        float dado = Random.Range(1f, 101f); // Sorteia um número de 1 a 100

        // Verifica se o número do dado caiu dentro da porcentagem de crítico
        if (dado <= jogador.ChanceDeCritico)
        {
            danoFinal = jogador.DanoCritico;
            Debug.Log("ACERTO CRÍTICO!");
        }

        AplicarDano(inimigo, danoFinal);
    }

    public void AcaoAtaquePesado()
    {
        // Verifica se há estamina suficiente (20 pontos)
        if (jogador.estaminaAtual >= 20f)
        {
            jogador.estaminaAtual -= 20f; // Gasta a estamina
            
            // Dano = Força + 30% da Força
            float danoFinal = jogador.forca + (jogador.forca * 0.30f); 
            
            Debug.Log("Ataque Pesado executado! Estamina restante: " + jogador.estaminaAtual);
            AplicarDano(inimigo, danoFinal);
        }
        else
        {
            Debug.Log("Estamina insuficiente para Ataque Pesado!");
        }
    }

    public void AcaoDefesa()
    {
        jogador.estaDefendendo = true; // Ativa a redução de 20%
        Debug.Log(jogador.nomePersonagem + " assumiu postura de Defesa!");
    }

    public void AcaoEsquiva()
    {
        if (jogador.estaminaAtual >= 15f)
        {
            jogador.estaminaAtual -= 15f;
            
            float dado = Random.Range(1f, 101f);
            if (dado <= jogador.ChanceDeEsquiva)
            {
                Debug.Log("Esquiva com SUCESSO! Estamina restante: " + jogador.estaminaAtual);
                // Aqui no futuro tocaremos a animação de esquiva bem-sucedida
            }
            else
            {
                Debug.Log("FALHOU na esquiva!");
            }
        }
        else
        {
            Debug.Log("Estamina insuficiente para Esquivar!");
        }
    }

    // Método interno para processar como o inimigo recebe o dano
    private void AplicarDano(UnidadeTatica alvo, float danoBruto)
    {
        float danoReal = danoBruto;

        // Se o alvo apertou o botão de defesa, reduz 20% do dano bruto
        if (alvo.estaDefendendo)
        {
            danoReal = danoBruto - (danoBruto * 0.20f);
        }

        // Aplica a redução passiva baseada nos pontos em Vida
        danoReal = danoReal - (danoReal * alvo.ReducaoDeDanoPassiva);
        alvo.vidaAtual -= danoReal;
        alvo.estaDefendendo = false; 

        Debug.Log(alvo.nomePersonagem + " sofreu " + danoReal + " de dano!");

        // NOVA CONDIÇÃO DE VITÓRIA/DERROTA PARA A ENTREGA 3
        if (alvo.vidaAtual <= 0)
        {
            alvo.vidaAtual = 0;
            if (alvo.nomePersonagem == "Askeladd")
            {
                Debug.Log("VITÓRIA! O inimigo foi derrotado.");
            }
            else
            {
                Debug.Log("DERROTA! Suas unidades caíram.");
            }
        }              
    }
}