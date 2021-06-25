using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies/Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    public int HP;
    public GameObject EnemyPrefab;
    public Color Color = new Color(1, 1, 0);

    public enum Types
    {
        poison,
        bandit,
        general
    }
    public Types EnemyType;
}
