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
    private bool caminando;
    private bool instantDrop;
    private bool pateando;
    public int animState = 1;
    //animState: 1 = Idle, 2 = Caminando, 3 = Salto, 4 = PrePatada, 5 = Patada
    
    private PlayerController moveScript;

    void Start(){
        moveScript = GetComponent<PlayerController>();
    }
    
    
    void Update(){
        //detectar si el personaje se mueve
        caminando = moveScript.walking;
        //detectar si el personaje está en el aire
        enElAire = moveScript.airborne;
        //detectar si el personaje está en el insta-drop
        if (moveScript.freezeTime > 0f){
            instantDrop = true;
        }else{
            instantDrop = false;
        }
        //detectar si el personaje esta a media patada
        if (moveScript.kickTime > 0f){
            pateando = true;
        }else{
            pateando = false;
        }
        if (pateando){
            animState = 5;
        }else if(instantDrop){
            animState = 4;
        }else if(enElAire){
            animState = 3;
        }else if(caminando){
            animState = 2;
        }else{
            animState = 1;
        }
        animator.SetInteger("animState", animState);
    }
}
