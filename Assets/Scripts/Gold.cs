using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Coin
{
    private void start()
    {
	value = 200;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
	player.score += value;
	Destroy(this.gameObject);
    }
}