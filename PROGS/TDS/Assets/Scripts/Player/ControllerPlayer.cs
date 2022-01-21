using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControllerPlayer : MonoBehaviour
{
    private Animator anim;

    public float speed;
    public Rigidbody2D rb;
    private Vector2 MoveInput;
    private Vector2 MoveVelosoty;

    public Joystick Move;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Animation();
    }

    void FixedUpdate()
    {
        MoveFunc();
    }
    private void MoveFunc()
    {
        MoveInput = new Vector2(Move.Horizontal, Move.Vertical);
        MoveVelosoty = MoveInput.normalized * speed;
        rb.MovePosition(rb.position + MoveVelosoty * Time.fixedDeltaTime);
    }
     private void Animation()
    {
        if (MoveInput.x != 0 || MoveInput.y != 0)
        {
            anim.SetBool("Run", true);
        }
        if(MoveInput.x > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        if (MoveInput.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        
    }
}
