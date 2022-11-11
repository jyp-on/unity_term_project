using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiControl : MonoBehaviour
{
    TextMeshProUGUI currentScoreText;
    TextMeshProUGUI currentLevelText;

    public float current_time;
    public int level = 0; //��ֹ� ��ȯ���� �����Ҷ� �ʿ�.

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
        currentScoreText.text = "�������� "+((int)current_score).ToString();
        currentLevelText.text = "���̵� "+level.ToString();
    }
    public IEnumerator levelUp()
    {
        while(true)
        {
            if(level >= 40) yield break; //�ִ볭�̵� 40

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
        else if(level < 40) current_score += 5f * Time.deltaTime; // 200�ʱ��� ����������� ����.

        else current_score += 10f * Time.deltaTime; //�ִ볭�̵� 40 (200�ʿ��� ���� �����)

    }
}
