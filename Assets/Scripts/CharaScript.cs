using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaScript : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float speed = 0.1f;
    public bool PlayerMove;

    public Animator animator;
    Vector2 move;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(PlayerMove) Move();
        else
        {
            body.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
        }
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
	    vertical = Input.GetAxisRaw("Vertical");

	    body.velocity = new Vector2(horizontal * speed, vertical * speed);

	    animator.SetFloat("Horizontal", horizontal);
	    animator.SetFloat("Vertical", vertical);

	    move.x = horizontal;
	    move.y = vertical;
	    animator.SetFloat("Speed", move.sqrMagnitude);
    }
}