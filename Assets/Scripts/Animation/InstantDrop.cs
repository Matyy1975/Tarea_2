using UnityEngine;

public class InstantDrop : MonoBehaviour
{
    public Animator animator;
    private bool instantDropActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            instantDropActive = true;
            animator.SetBool("Instant Drop", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            instantDropActive = false;
            animator.SetBool("Instant Drop", false);
        }
    }
}
