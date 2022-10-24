using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    public GuiControl guiControl;
    void Awake()
    {
        guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
        Cursor.lockState = CursorLockMode.None; 
        guiControl.isPlay = false;
    }
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Play");
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void onClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OnGUI() 
    {
        GUI.skin.label.fontSize = 40;
        GUI.Label(new Rect(Screen.width/2 - 350, Screen.height/2 + 50, 500,200), "생존시간 : "+((int)guiControl.current_time).ToString()+"초");
        GUI.Label(new Rect(Screen.width/2 + 170, Screen.height/2 + 50, 500,200), "난이도 : "+guiControl.level);
    }
        
}
