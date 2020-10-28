using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=7;
    public float rotationSpeed=250;
    public Animator animator;
    private float x,y;
    public Camera camPersonaje;

    public Rigidbody rb;
    public float jumpHeight=3;
    public Transform groundCheck;
    public float groundDistance=0.6f;
    public LayerMask groundMask;
    bool isGrounded;
    int intSalto;
    
    // Start is called before the first frame update
    void Start()
    {
        camPersonaje.enabled=true;
        runSpeed=7;
        rotationSpeed=130;
        jumpHeight=1.5f;
        
        isGrounded=false;
        groundDistance=0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded=Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
      
        x=Input.GetAxis("Horizontal");
        y=Input.GetAxis("Vertical");

        transform.Rotate(0,x*Time.deltaTime*rotationSpeed,0);
        transform.Translate(0,0,y*Time.deltaTime*runSpeed);

        animator.SetFloat("VelX",x);
        animator.SetFloat("VelY",y);

        if (Input.GetKey("f")){
            animator.SetBool("Other",false);
            animator.Play("Dance");
        }
        if (Input.GetKey("space")&&isGrounded){
            Debug.Log("salto");
            animator.SetBool("Other",false);
            animator.Play("Jumping");
            rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
            //Invoke("Jump",0.1f);
            
        }
        if(x>0||x<0 ||y>0 ||y<0){
            animator.SetBool("Other",true);
        }

        
    }

    public void Jump(){
        rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
    }
}
