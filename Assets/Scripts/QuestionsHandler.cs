using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionsHandler", menuName = "ScriptableObjects/Questions/QuestionsHandler")]
public class QuestionsHandler : ScriptableObject
{
    public Question[] Questions;
    private List<Question> CorrectQuestions = new List<Question>();
    private List<Question> IncorrectQuestions = new List<Question>();

    public Question GetRandomQuestion()
    {
        int index = Random.Range(0, Questions.Length - 1);
        return Questions[index];
    }

    public void AnswerCorrect(Question question)
    {
        if (!CorrectQuestions.Contains(question))
        {
            CorrectQuestions.Add(question);
            if (IncorrectQuestions.Contains(question)) IncorrectQuestions.Remove(question);
        }
    }

    public void AnswerIncorrect(Question question)
    {
        if (!IncorrectQuestions.Contains(question)) IncorrectQuestions.Add(question);
    }
}
