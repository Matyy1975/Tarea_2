using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public Animator animator;
    public string parametroCaminar = "Caminando";
    public string parametroIdle = "Idle";
    public string parametroJump = "Jump";
    public string parametroKick = "Kick";
    private bool enElAire;

    void Update()
    {
        // Detectar si el personaje est� en el aire
        if (enElAire)
        {
            // Detectar si se presiona la tecla "Space" para activar la animaci�n de salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActivarSalto(true);
            }
        }
        else
        {
            // Detectar si se presiona la tecla "Space" para activar la animaci�n de salto mientras est� en el suelo
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

        // Detectar si se presiona la tecla espec�fica para activar la animaci�n de patada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ActivarPatada();
        }

        // Detectar si se suelta la tecla espec�fica para desactivar la animaci�n de patada
        if (Input.GetKeyUp(KeyCode.Z))
        {
            DesactivarPatada();
        }
    }

    void ActivarCaminar(bool activar)
    {
        animator.SetBool(parametroCaminar, activar);
    }

    void ActivarIdle()
    {
        animator.SetBool(parametroCaminar, false);
        animator.SetBool(parametroJump, false);
        animator.SetBool(parametroKick, false);
        animator.Play(parametroIdle, -1, 0f);
    }

    void ActivarSalto(bool activar)
    {
        animator.SetBool(parametroJump, activar);
    }

    void ActivarPatada()
    {
        animator.SetBool(parametroKick, true);
        animator.Play(parametroKick, -1, 0f); // Reproducir la animaci�n de patada desde el inicio instant�neamente
    }

    void DesactivarPatada()
    {
        animator.SetBool(parametroKick, false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElAire = false;
            ActivarSalto(false);
            ActivarIdle();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElAire = true;
            ActivarSalto(true);
        }
    }
}
