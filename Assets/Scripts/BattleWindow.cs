using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleWindow : MonoBehaviour
{
    public Text QuestionText, Answer1Text, Answer2Text, Answer3Text;
    public GameObject BattleWindowPanel;
    private Question CurrentQuestion;
    public Question DebugQuestion;
    // Start is called before the first frame update
    void Start()
    {
        SetQuestion(DebugQuestion);
    }

    public void AnswerButton(int buttonIndex)
    {
        if(buttonIndex == CurrentQuestion.CorrectAnswer)
        {
            Debug.Log("AnswerButton pressed: is correct");
        }
        else
        {
            Debug.Log("AnswerButton pressed: is incorrect");
        }
        
    }

    private void BattleWindowVisible(bool isVisible)
    {
        BattleWindowPanel.SetActive(isVisible);
    }

    public void SetQuestion(Question question)
    {
        CurrentQuestion = question;
        DisplayQuestion();
    }

    public void DisplayQuestion()
    {
        QuestionText.text = CurrentQuestion.QuestionStr;
        Answer1Text.text = CurrentQuestion.Answer1;
        Answer2Text.text = CurrentQuestion.Answer2;
        Answer3Text.text = CurrentQuestion.Answer3;
        BattleWindowVisible(true);
    }
}
