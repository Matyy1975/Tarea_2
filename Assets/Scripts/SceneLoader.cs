using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string sceneName;
    public float delay = 1f;
    private bool transitioning = false;
    private float timePassed = 0f;
    private Animator fadeAnimator;

    public void Start()
    {
        fadeAnimator = GameObject.Find("Fade").GetComponent<Animator>();
    }

    public void Update()
    {
        if (transitioning)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= delay)
            {
                Time.timeScale = 1f;  // Reanudar la escala de tiempo normal
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void LoadScene()
    {
        Time.timeScale = 1f;
        fadeAnimator.SetBool("Fade", true);
        transitioning = true;
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
