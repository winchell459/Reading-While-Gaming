﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionsHandler", menuName = "ScriptableObjects/Questions/QuestionsHandler")]
public class QuestionsHandler : ScriptableObject
{
    public Question[] Questions;
    [SerializeField] private List<Question> CorrectQuestions = new List<Question>();
    [SerializeField] private List<Question> IncorrectQuestions = new List<Question>();

    public Question GetRandomQuestion()
    {
        List<Question> unAnsweredQuestions = GetUnansweredQuestions();
        int index = Random.Range(0, unAnsweredQuestions.Count);
        return unAnsweredQuestions[index];
    }

    private List<Question> GetUnansweredQuestions()
    {
        List<Question> questions = new List<Question>();
        foreach(Question question in Questions)
        {
            if (!CorrectQuestions.Contains(question)) questions.Add(question);
        }
        return questions;
    }

    public void AnswerCorrect(Question question)
    {
        if (!CorrectQuestions.Contains(question))
        {
            CorrectQuestions.Add(question);
        }
        if (IncorrectQuestions.Contains(question)) IncorrectQuestions.Remove(question);
    }

    public void AnswerIncorrect(Question question)
    {
        if (!IncorrectQuestions.Contains(question)) IncorrectQuestions.Add(question);
    }

    public void ClearCorrectQuestions()
    {
        CorrectQuestions.Clear();
    }
}