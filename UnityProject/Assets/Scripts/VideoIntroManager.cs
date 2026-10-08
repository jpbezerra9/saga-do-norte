using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.InputSystem; // Importante para o novo Input System

public class VideoIntroManager : MonoBehaviour
{
    [Header("Configurações do Vídeo")]
    public VideoPlayer videoPlayer;
    public string nomeDaCenaDoMenu = "MenuPrincipal";

    void Start()
    {
        if (videoPlayer != null)
        {
            // O evento 'loopPointReached' é acionado automaticamente quando o vídeo chega ao fim
            videoPlayer.loopPointReached += AoTerminarOVideo;
        }
    }

    void Update()
    {
        // Verifica se a barra de espaço foi pressionada usando o novo Input System
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            IrParaMenu();
        }
    }

    private void AoTerminarOVideo(VideoPlayer vp)
    {
        IrParaMenu();
    }

    private void IrParaMenu()
    {
        SceneManager.LoadScene(nomeDaCenaDoMenu);
    }
}