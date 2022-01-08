using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObject/Questions/Question")]
public class Question : ScriptableObject
{
    [TextArea]public string QuestionStr = "";
    [TextArea] public string Answer1, Answer2, Answer3;
    [Range(1,3)]public int CorrectAnswer;
    [Range(1, 10)] public int Difficulty;
}