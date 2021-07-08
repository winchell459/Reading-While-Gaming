using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemies/Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    public int HP;
    public GameObject EnemyPrefab;
    public Sprite EnemyBackground;
    public Color Color = Color.white;

    public enum Types
    {
        Poison,
        Bandit,
        Someguy,
        Lakemonster,
        Chest,
    }

    public Types EnemyType;
}