using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform TeleportLocation;
    private void Start()
    {
        Debug.Log($"Door scripts is on {gameObject.name}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = TeleportLocation.position;
        }
    }
}