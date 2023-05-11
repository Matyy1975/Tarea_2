using UnityEngine;

public class FullscreenTicket : MonoBehaviour
{
    public GameObject ticketPrefab;

    private bool isFullscreen = false;
    private GameObject currentTicket;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Verificar si se hizo clic en el cuadradito
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = GetComponent<Collider2D>();
            if (collider.OverlapPoint(mousePosition))
            {
                if (!isFullscreen)
                {
                    // Crear y mostrar el ticket
                    currentTicket = Instantiate(ticketPrefab, transform.position, Quaternion.identity);
                    currentTicket.transform.SetParent(transform);
                    currentTicket.transform.localScale = Vector3.one;
                    isFullscreen = true;

                    // Cambiar a pantalla completa
                    ToggleFullscreen(true);
                }
                else
                {
                    // Destruir el ticket y volver al modo de pantalla normal
                    Destroy(currentTicket);
                    isFullscreen = false;

                    // Salir de la pantalla completa
                    ToggleFullscreen(false);
                }
            }
        }
    }

    private void ToggleFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}
