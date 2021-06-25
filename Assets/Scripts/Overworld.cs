using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld : MonoBehaviour
{
    public string BattleSceneName = "BattleSetUp";
    public Transform Player;
    public Vector2 StartPoint;

    void Start()
    {
        LoadOverworld();
    }

    private void LoadOverworld()
    {
        PlayerHandler player = FindObjectOfType<PlayerHandler>();
        int LastSpawnDefeat = player.LastEnemyDefeated();

        if(LastSpawnDefeat == -1)
        {
            Player.transform.position = StartPoint;
        }
        else
        {
            Spawn[] sp = FindObjectsOfType<Spawn>();
            foreach(Spawn point in sp)
            {
                if(player.isEnemySpawnDefeated(point.SpawnPointID))
                {
                    if (point.SpawnPointID == LastSpawnDefeat) Player.transform.position = (Vector2)point.transform.position;
                    point.gameObject.SetActive(false);
                }
            }
        }
    }

    public void PlayerAttacked(Enemy.Types AttackType, int SpawnPointID)
    {
        PlayerHandler player = FindObjectOfType<PlayerHandler>();
        player.OverworldPos = Player.transform.position;
        player.AttackedType = AttackType;
        player.CurrentEnemyID = SpawnPointID;
        LoadBattle();
    }

    private void LoadBattle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(BattleSceneName);
    }
}