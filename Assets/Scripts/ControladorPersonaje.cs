using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public Animator animator;
    public string parametroCaminar = "Caminando";
    public string parametroIdle = "Idle";
    public string parametroJump = "Jump";
    private bool enElAire;

    void Update()
    {
        // Detectar si el personaje está en el aire
        if (enElAire)
        {
            // Detectar si se presiona la tecla "Space" para activar la animación de salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActivarSalto(true);
            }
        }
        else
        {
            // Detectar si se presiona la tecla "Space" para activar la animación de salto mientras está en el suelo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActivarSalto(true);
                ActivarCaminar(false);
            }
        }

        // Detectar si se presiona la tecla "A" (izquierda)
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivarCaminar(true);
        }

        // Detectar si se presiona la tecla "D" (derecha)
        if (Input.GetKeyDown(KeyCode.D))
        {
            ActivarCaminar(true);
        }

        // Detectar si se suelta la tecla "A" o "D"
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            ActivarCaminar(false);
            ActivarIdle();
        }
    }

    void ActivarCaminar(bool activar)
    {
        animator.SetBool(parametroCaminar, activar);
    }

    void ActivarIdle()
    {
        animator.SetBool(parametroCaminar, false); // Asegurarse de desactivar la animación de caminar
        animator.SetBool(parametroJump, false); // Asegurarse de desactivar la animación de salto
        animator.Play(parametroIdle, -1, 0f); // Reproducir la animación de idle desde el inicio instantáneamente
    }

    void ActivarSalto(bool activar)
    {
        animator.SetBool(parametroJump, activar);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detectar si el personaje ha aterrizado en una superficie
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElAire = false;
            ActivarSalto(false);
            ActivarIdle();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Detectar si el personaje ha dejado de estar en contacto con una superficie
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElAire = true;
            ActivarSalto(true);
        }
    }
}
