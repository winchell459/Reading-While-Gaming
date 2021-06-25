using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Enemy.Types EnemyType;
    public GameObject EnemyPrefab;
    public bool isActive = true;
    public int SpawnPointID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isActive)
        {
            FindObjectOfType<Overworld>().PlayerAttacked(EnemyType, SpawnPointID);
        }
    }
}
