using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject goalPrefab;
    public GameObject boss;

    private void Start()
    {
        // Desactivar el prefab "goal" al inicio
        goalPrefab.SetActive(false);
    }

    private void Update()
    {
        // Verificar si el jefe sigue vivo
        if (boss != null)
        {
            // El jefe está vivo, desactivar el prefab "goal"
            goalPrefab.SetActive(false);
        }
        else
        {
            // El jefe ha sido derrotado o destruido, activar el prefab "goal"
            goalPrefab.SetActive(true);
        }
    }
}
