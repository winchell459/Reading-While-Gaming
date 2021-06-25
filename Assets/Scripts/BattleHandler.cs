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

    public enum BattleStates
    {
        Start,
        Questioning,
        Answering,
        Actions,
        Ending
    }
    private BattleStates BattleState;

    bool AnswerSubmitted = false;
    Question CurrentQuestion;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHandler player = FindObjectOfType<PlayerHandler>();
        Enemy = EnemyHandler.GetRandomEnemy(player.AttackedType);
    }

    // Update is called once per frame
    void Update()
    {
        HandleBattleStates();
    }

    private void HandleBattleStates()
    {
        switch (BattleState)
        {
            case BattleStates.Start:
                //Animations and other setup befor the battle
                StartBattle();
                BattleState += 1;
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
                    if(questionAnswer == CurrentQuestion.CorrectAnswer)
                    {
                        Attack();
                        Questions.AnswerCorrect(CurrentQuestion);
                        Debug.Log("Answer Correct");
                    }
                    else
                    {
                        BeAttacked();
                        Questions.AnswerIncorrect(CurrentQuestion);
                        Debug.Log("Answer Incorrect");
                    }
                    BattleState += 1;
                }
                break;
            case BattleStates.Actions:
                if(!PlayerHPBar.isDraining && !EnemyHPBar.isDraining)
                {
                    if(PlayerHPBar.GetHP() > 0 && EnemyHPBar.GetHP() > 0)
                    {
                        BattleState = BattleStates.Questioning;
                    }
                    else
                    {
                        if(PlayerHPBar.GetHP() > 0)
                        {
                            PlayerHandler player = FindObjectOfType<PlayerHandler>();
                            player.EnemyDefeated(player.CurrentEnemyID);
                        }
                        BattleState += 1;
                    }
                    
                }
                
                break;
            case BattleStates.Ending:

                UnityEngine.SceneManagement.SceneManager.LoadScene("OverWorld");
                break;
            default:

                break;
        }

        

    }

    private void BeAttacked()
    {
        int damage = CurrentQuestion.Difficulty * 10;
        PlayerHPBar.ReduceHP(damage);
    }

    private void Attack()
    {
        int damage = CurrentQuestion.Difficulty * 10;
        EnemyHPBar.ReduceHP(damage);
    }

    private void StartBattle()
    {
        PlayerHPBar.SetupHealthBar("Player:", Player.MaxHP, new Color(1, 0, 0));
        PlayerHPBar.SetHP(Player.HP);
        EnemyHPBar.SetupHealthBar(Enemy.Name, Enemy.HP, Enemy.Color);
    }

    int questionAnswer;
    public void QuestionAnswered(int answer)
    {
        questionAnswer = answer;
        AnswerSubmitted = true;
    }
}
