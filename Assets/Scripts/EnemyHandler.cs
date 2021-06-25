using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyHandler", menuName = "ScriptableObject/Enemies/EnemyHandler")]
public class EnemyHandler : ScriptableObject
{
    public Enemy[] Enemies;

    public Enemy GetEnemy(string name)
    {
        foreach(Enemy enemy in Enemies)
        {
            if (enemy.Name == name) return enemy;
        }

        Debug.LogWarning("Enemy name not found: " + name);
        return null;
    }

    public Enemy GetRandomEnemy()
    {
        int index = Random.Range(0, Enemies.Length);
        return Enemies[index];
    }

    public Enemy GetRandomEnemy(Enemy.Types type)
    {
        List<Enemy> enemies = GetEnemies(type);
        int index = Random.Range(0, enemies.Count);
        if (enemies.Count > 0) return enemies[index];
        else
        {
            Debug.Log("No enemy found of type " + type);
            return null;
        }
    }

    public List<Enemy> GetEnemies(Enemy.Types type)
    {
        List<Enemy> enemies = new List<Enemy>();
        foreach(Enemy enemy in Enemies)
        {
            if (enemy.EnemyType == type) enemies.Add(enemy);
        }
        return enemies;
    }
}