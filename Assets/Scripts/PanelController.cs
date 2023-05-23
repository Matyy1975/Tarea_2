using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panelToActivate; // Referencia al panel que se mostrará al activar este panel
    public GameObject previousPanel; // Referencia al panel anterior que se mostrará al presionar el botón de volver

    public void ActivatePanel()
    {
        gameObject.SetActive(false); // Desactiva este panel
        panelToActivate.SetActive(true); // Activa el panel siguiente
    }

    public void ActivatePreviousPanel()
    {
        gameObject.SetActive(false); // Desactiva este panel
        previousPanel.SetActive(true); // Activa el panel anterior
    }
}
