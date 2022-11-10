using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    TextMeshProUGUI bestScoreText;
    private int current_score;
    // Start is called before the first frame update

    void Start()
    {
        bestScoreText = GetComponent<TextMeshProUGUI>();
        current_score = PlayerPrefs.GetInt("current_score"); 

        bestScoreText.text = "현재점수\n"+current_score.ToString()+"초";
    }
}
