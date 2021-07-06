using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemies/Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    public int HP;
    public GameObject EnemyPrefab;
    public Color Color;
    public Sprite Background;

    public enum Types
    {
        Poison,
        Bandit,
        Someguy,
        Lakemonster,
    }

    public Types EnemyType;
}