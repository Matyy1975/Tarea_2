using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panelToActivate; // Referencia al panel que se mostrar� al activar este panel
    public GameObject previousPanel; // Referencia al panel anterior que se mostrar� al presionar el bot�n de volver

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
