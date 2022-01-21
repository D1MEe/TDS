using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Controller : MonoBehaviour
{
    public float speed;

    private float HorMove;
    private float VerMove;
    private Animator anim;

    
    public Joystick MoveJoystick;
    private Vector2 MoveInput;
    private Vector2 MoveVelosety;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        anim.GetComponent<Animator>();
    }
    void Update()
    {

        HorMove = Input.GetAxisRaw("Horizontal");
        VerMove = Input.GetAxisRaw("Vertical");
        Move();
        Anim();
    }

    void Move()
    {
        if ((int)HorMove < 0)
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
        }
        else if ((int)HorMove > 0)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if ((int)VerMove < 0)
        {
            transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }
        if ((int)VerMove > 0)
        {
            transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
    }
    void Anim()
    {
        if(HorMove != 0)
            anim.SetBool("Run", true);

        if(VerMove != 0)
            anim.SetBool("Run", true);
    }
}
