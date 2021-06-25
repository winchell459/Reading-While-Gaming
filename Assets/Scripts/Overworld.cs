using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld : MonoBehaviour
{
    public string BattleSceneName = "BattleSetup";
    public Transform Player;
    public Vector2 StartPoint;
    // Start is called before the first frame update
    void Start()
    {

        LoadOverWorld();

    }

    private void LoadOverWorld()
    {
        PlayerHandler player = FindObjectOfType<PlayerHandler>();
        int lastSpawnDefeat = player.LastEnemyDefeated();
        if(lastSpawnDefeat == -1)
        {
            Player.transform.position = StartPoint;
        }
        else
        {
            SpawnPoint[] sp = FindObjectsOfType<SpawnPoint>();
            foreach(SpawnPoint point in sp)
            {
                if (player.isEnemySpawnDefeated(point.SpawnPointID))
                {
                    if (point.SpawnPointID == lastSpawnDefeat) Player.transform.position = (Vector2)point.transform.position;
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
