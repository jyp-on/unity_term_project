using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gui : MonoBehaviour
{
    private float current_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        current_time += Time.deltaTime;
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(10, 10, 500,200), "생존시간 : "+((int)current_time).ToString());
    }
}
