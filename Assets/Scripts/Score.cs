using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;

    public CharaScript player;

    void Update()
    {
        score.text = "Score: " + player.score;
    }
}
