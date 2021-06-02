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

    public Animator animator;
    Vector2 move;
    public int score;
    public int outside;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
	score = 0;
	outside = 1;

	if(SceneManager.GetActiveScene().buildIndex == outside)
	{
	    this.transform.position = PlayerData.pos;
	}
    }

    // Update is called once per frame
    void Update()
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