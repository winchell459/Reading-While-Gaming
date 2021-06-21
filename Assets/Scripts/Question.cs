using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Questions/Question")]
public class Question : ScriptableObject
{
    [TextArea]public string QuestionStr = "Please enter question here.";
    [TextArea]public string Answer1, Answer2, Answer3;
    [Range(1, 3)]public int CorrectAnswer;
    [Range(1, 10)] public int Difficulty;

    public enum Themes
    {
        General,
        Nature,
        Building,
        Enemies,
        SomethingElse,
    }

    public Themes Theme;
}
