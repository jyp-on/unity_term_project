using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuiControl : MonoBehaviour
{
    public float current_time;
    public int level = 0;
    public bool isPlay;
    // Start is called before the first frame update
    void Awake()
    {
        isPlay = true;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        StartCoroutine(levelUp());
    }
    void Update() 
    {
        if(isPlay)
            current_time += Time.deltaTime;
    }
    
    void OnGUI()
    {
        GUI.skin.label.fontSize = 30;
        GUI.Label(new Rect(10, 10, 700,200), "�����ð� : "+((int)current_time).ToString()+"��");
        GUI.Label(new Rect(10, 50, 700,200), "���̵� : "+level);
    }
    public IEnumerator levelUp()
    {
        while(true)
        {
            if(isPlay)
                level += 1;
                yield return new WaitForSeconds(5.0f);
        }
    }
}
