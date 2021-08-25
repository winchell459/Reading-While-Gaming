using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int HP = 500;
    public int MaxHP = 1000;
    public static PlayerHandler Singleton;
    public Color Color;

    public Vector2 OverworldPos;
    public Enemy.Types AttackedType;
    public int CurrentEnemyID;

    public List<int> EnemySpawnDefeated = new List<int>();
    List<int> DialogueCompleted = new List<int>();

    public QuestionsHandler QH;

    void Start()
    {
        if(Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
            QH.ClearCorrectQuestions();
        }
    }

    public bool isEnemySpawnDefeated(int spawnID)
    {
        return EnemySpawnDefeated.Contains(spawnID);
    }

    public void EnemyDefeated(int spawnID)
    {
        EnemySpawnDefeated.Add(spawnID);
    }

    public int LastEnemyDefeated()
    {
        if (EnemySpawnDefeated.Count > 0) return EnemySpawnDefeated[EnemySpawnDefeated.Count - 1];
        else return -1;
    }

    public void SetDialogueCompleted(int dialogueID)
    {
        DialogueCompleted.Add(dialogueID);
    }
    public bool IsDialogueCompleted(int dialogueID)
    {
        return !DialogueCompleted.Contains(dialogueID);
    }
}