using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuiControl : MonoBehaviour
{
    public float current_time;
    public int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(levelUp());
    }
    void LateUpdate() 
    {
        current_time += Time.deltaTime;
    }
    
    void OnGUI()
    {
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(10, 10, 500,200), "생존시간 : "+((int)current_time).ToString()+"초");
        GUI.Label(new Rect(10, 50, 500,200), "난이도 : "+level);
    }
    IEnumerator levelUp()
    {
        while(true)
        {
            level += 1;
            yield return new WaitForSeconds(5.0f);
        }
    }
}
