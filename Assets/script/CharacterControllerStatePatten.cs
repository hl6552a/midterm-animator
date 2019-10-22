using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStatePatten : MonoBehaviour
{
    Rigidbody rb;
    public float wSpeed;
    public float rotSpeed;
    enum Mages_STATE {S_WALK, S_IDLE, S_ATTACK1, S_ATTACK2};
    Mages_STATE state;
    Animator anim;

  
    // Start is called before the first frame update
    void Start()
    {   rb = this.GetComponent<Rigidbody>();
        state = Mages_STATE.S_IDLE;
        anim = GetComponent<Animator>();
        
    }

 
    // Update is called once per frame
    void Update()
    {
        var z = Input.GetAxis("Vertical") * wSpeed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);


        switch (state)
        {
            case Mages_STATE.S_IDLE:
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    state = Mages_STATE.S_WALK;
                    anim.SetTrigger("Walk");    
                }

                break;

            case Mages_STATE.S_WALK:
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    state = Mages_STATE.S_IDLE;
                    anim.SetTrigger("Idle");
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = Mages_STATE.S_ATTACK1;
                    anim.SetTrigger("Attack1");
                }
                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {  
                    state = Mages_STATE.S_ATTACK2;
                    anim.SetTrigger("Attack2");
                    
                }
                break;


            case Mages_STATE.S_ATTACK1:

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    state = Mages_STATE.S_WALK;
                    anim.SetTrigger("Walk");
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    state = Mages_STATE.S_IDLE;
                    anim.SetTrigger("Idle");


                }
                break;



            case Mages_STATE.S_ATTACK2:
                if (Input.GetKeyUp(KeyCode.LeftAlt))
                {
                    state = Mages_STATE.S_WALK;
                    anim.SetTrigger("Walk");
                }
                if (Input.GetKeyUp(KeyCode.W))
                    {
                    state = Mages_STATE.S_IDLE;
                    anim.SetTrigger("Idle");

                    }



                break;

                

        }
    }
}