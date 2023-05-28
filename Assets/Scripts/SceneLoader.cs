using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string sceneName;

    public void LoadScene()
    {
        Time.timeScale = 1f;  // Reanudar la escala de tiempo normal
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
