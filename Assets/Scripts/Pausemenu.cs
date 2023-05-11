using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;  // Reanudar la escala de tiempo normal
        isGamePaused = false;

        // Ocultar el menú de pausa
        pauseMenu.SetActive(false);

        // Otras acciones para reanudar el juego, si es necesario
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;  // Detener la escala de tiempo
        isGamePaused = true;

        // Mostrar el menú de pausa
        pauseMenu.SetActive(true);

        // Otras acciones para pausar el juego, si es necesario
    }
}
