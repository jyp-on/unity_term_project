using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiControl : MonoBehaviour
{
    TextMeshProUGUI currentScoreText;
    TextMeshProUGUI currentLevelText;

    public float current_time;
    public int level = 0;

    void Start()
    {
        currentScoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        currentLevelText = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();

        StartCoroutine(levelUp());
    }
    void Update() 
    {
        current_time += Time.deltaTime;

        currentScoreText.text = "�������� "+((int)current_time).ToString();
        currentLevelText.text = "���̵� "+level.ToString();
    }
    public IEnumerator levelUp()
    {
        while(true)
        {
            level += 1;
            yield return new WaitForSeconds(5.0f);
        }
    }
}
