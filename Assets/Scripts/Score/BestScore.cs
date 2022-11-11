using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BestScore : MonoBehaviour
{
    TextMeshProUGUI bestScoreText;
    private int best_score;
    // Start is called before the first frame update

    void Start()
    {
        bestScoreText = GetComponent<TextMeshProUGUI>();
        best_score = PlayerPrefs.GetInt("best_score"); 

        bestScoreText.text = "최고점수 \n"+best_score.ToString()+"점";
    }
}
