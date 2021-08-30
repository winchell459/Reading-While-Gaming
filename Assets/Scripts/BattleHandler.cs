using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public QuestionsHandler Questions;
    public BattleWindow BattleWindow;

    public HealthBar PlayerHPBar, EnemyHPBar;

    [SerializeField] private PlayerHandler Player;
    [SerializeField] private Enemy Enemy;

    public EnemyHandler EnemyHandler;

    public SpriteRenderer Background;
    public Transform EnemySpawnPoint;

    private bool battleWon;

    public float QuestionWaitTime = 1;
    float questionWaitStart = float.MinValue;

    public enum BattleStates
    {
        Start,
        QuestionStart,
        Questioning,
        Answering,
        Actions,
        Ending,
    }

    public BattleStates BattleState;

    bool AnswerSubmitted = false;
    Question CurrentQuestion;

    void Start()
    {
        Player = FindObjectOfType<PlayerHandler>();
        Enemy = EnemyHandler.GetRandomEnemy(Player.AttackedType);
        Background.sprite = Enemy.EnemyBackground;
        Instantiate(Enemy.EnemyPrefab, EnemySpawnPoint);
    }

    void Update()
    {
        HandleBattleStates();
    }

    private void HandleBattleStates()
    {
        switch (BattleState)
        {
            case BattleStates.Start:
                StartBattle();
                BattleState += 1;
                break;
            case BattleStates.QuestionStart:
                if (questionWaitStart + QuestionWaitTime < Time.time)
                {
                    BattleState += 1;
                }
                break;
            case BattleStates.Questioning:
                CurrentQuestion = Questions.GetRandomQuestion();
                BattleWindow.SetQuestion(CurrentQuestion);
                AnswerSubmitted = false;
                BattleState += 1;
                break;

            case BattleStates.Answering:
                if (AnswerSubmitted)
                {
                    if (questionAnswer == CurrentQuestion.CorrectAnswer)
                    {
                        Attack();
                        Questions.AnswerCorrect(CurrentQuestion);
                        Debug.Log("Correct Answer");
                    }
                    else
                    {
                        BeAttacked();
                        Questions.AnswerIncorrect(CurrentQuestion);
                        Debug.Log("Wrong Answer");
                    }

                    BattleState += 1;
                }
                break;

            case BattleStates.Actions:
                if (!PlayerHPBar.isDraining && !EnemyHPBar.isDraining)
                {
                    if (PlayerHPBar.GetHP() > 0 && EnemyHPBar.GetHP() > 0)
                    {
                        questionWaitStart = Time.time;
                        BattleState = BattleStates.QuestionStart;
                    }
                    else
                    {
                        if (PlayerHPBar.GetHP() > 0)
                        {
                            Player.EnemyDefeated(Player.CurrentEnemyID);
                            battleWon = true;
                        }
                        BattleState += 1;
                    }
                }
                break;

            case BattleStates.Ending:
                if (Enemy.EnemyType == Enemy.Types.Chest && battleWon == true)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Overworld");
                }
                break;

            default:
                break;
        }
    }

    private void BeAttacked()
    {
        int damage = CurrentQuestion.Difficulty * 16;
        PlayerHPBar.ReduceHP(damage);
    }

    private void Attack()
    {
        int damage = CurrentQuestion.Difficulty * 17;
        EnemyHPBar.ReduceHP(damage);
    }

    private void StartBattle()
    {
        questionWaitStart = Time.time;
        PlayerHPBar.SetUpHealthBar("Player:", Player.MaxHP, Player.Color);
        PlayerHPBar.SetHP(Player.HP);
        EnemyHPBar.SetUpHealthBar(Enemy.Name, Enemy.HP, Enemy.Color);
    }

    int questionAnswer;

    public void QuestionAnswered(int answer)
    {
        questionAnswer = answer;
        AnswerSubmitted = true;
    }
}