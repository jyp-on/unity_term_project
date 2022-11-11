using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiControl : MonoBehaviour
{
    TextMeshProUGUI currentScoreText;
    TextMeshProUGUI currentLevelText;

    public float current_time;
    public int level = 0; //장애물 소환간격 조정할때 필요.

    public static float current_score = 0;

    void Start()
    {
        currentScoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        currentLevelText = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();

        StartCoroutine(levelUp());
    }
    void Update() 
    {
        Score();
        currentScoreText.text = "현재점수 "+((int)current_score).ToString();
        currentLevelText.text = "난이도 "+level.ToString();
    }
    public IEnumerator levelUp()
    {
        while(true)
        {
            if(level >= 40) yield break; //최대난이도 40

            level += 1;
            yield return new WaitForSeconds(5.0f);
        }
    }

    void Score()
    {
        current_time += Time.deltaTime;
        if(level <= 5) current_score += 0.2f * Time.deltaTime;
        else if(level <= 10) current_score += 0.4f * Time.deltaTime;
        else if(level <= 15) current_score += 0.6f * Time.deltaTime;
        else if(level <= 20) current_score += 1f * Time.deltaTime;
        else if(level <= 25) current_score += 1.5f * Time.deltaTime;
        else if(level <= 30) current_score += 2f * Time.deltaTime;
        else if(level <= 35) current_score += 3f * Time.deltaTime;
        else if(level < 40) current_score += 5f * Time.deltaTime; // 200초까지 어려워지도록 구현.

        else current_score += 10f * Time.deltaTime; //최대난이도 40 (200초에서 가장 어려움)

    }
}
