using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : Coin
{
    private void start()
    {
	value = 100;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
	player.score += value;
	Destroy(this.gameObject);
    }
}