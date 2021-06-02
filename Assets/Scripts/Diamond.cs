using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Coin
{
    private void start()
    {
	value = 300;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
	player.score += value;
	Destroy(this.gameObject);
    }
}