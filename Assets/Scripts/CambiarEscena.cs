using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void CargarEscena()
    {
        SceneManager.LoadScene("Levels");
    }
}
