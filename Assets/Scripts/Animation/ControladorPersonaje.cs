using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public Animator animator;
    public string parametroIdle = "Idle";
    public string parametroJump = "Jump";
    public string parametroKick = "Kick";
    public string parametroMove = "Move";
    private bool enElAire;
    private bool saltando;

    void Update()
    {
        // Detectar si el personaje está en el aire
        if (enElAire)
        {
            // Detectar si se presiona la tecla "Space" para activar la animación de salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                saltando = true;
                ActivarSalto(true);
            }
        }
        else
        {
            // Detectar si se presiona la tecla "Space" para activar la animación de salto mientras está en el suelo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                saltando = true;
                ActivarSalto(true);
                ActivarMove(false);
            }
        }

        // Detectar si se presiona la tecla "A" (izquierda)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ActivarMove(true);
        }

        // Detectar si se presiona la tecla "D" (derecha)
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ActivarMove(true);
        }

        // Detectar si se suelta la tecla "A" o "D"
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            ActivarIdle();
            ActivarMove(false);
        }

        // Detectar si se presiona la tecla específica para activar la animación de patada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ActivarPatada();
        }

        // Detectar si se suelta la tecla específica para desactivar la animación de patada
        if (Input.GetKeyUp(KeyCode.Z))
        {
            DesactivarPatada();
        }
    }

    void ActivarIdle()
    {
        animator.SetBool(parametroJump, false);
        animator.SetBool(parametroKick, false);
        animator.Play(parametroIdle, -1, 0f);
    }

    void ActivarSalto(bool activar)
    {
        animator.SetBool(parametroJump, activar);
        if (!activar && saltando)
        {
            saltando = false;
            ActivarMove(false);
        }
    }

    void ActivarPatada()
    {
        animator.SetBool(parametroKick, true);
        animator.Play(parametroKick, -1, 0f); // Reproducir la animación de patada desde el inicio instantáneamente
    }

    void DesactivarPatada()
    {
        animator.SetBool(parametroKick, false);
    }

    void ActivarMove(bool activar)
    {
        animator.SetBool(parametroMove, activar);
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
}
