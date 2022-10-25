using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    private int current_score;
    private int best_score;
    private int level;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None; 

        current_score = PlayerPrefs.GetInt("current_score");
        best_score = PlayerPrefs.GetInt("best_score");
        level = PlayerPrefs.GetInt("level");
    }
    public void OnClickNewGame()
    {
        Destroy(GameObject.Find("GameManager"));
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
        GUI.Label(new Rect(Screen.width/2 - 350, Screen.height/2 + 50, 800,300), "현재점수 : "+current_score.ToString()+"초");
        GUI.Label(new Rect(Screen.width/2 - 350, Screen.height/2 + 100, 800,300), "최고점수 : "+best_score.ToString()+"초");
        GUI.Label(new Rect(Screen.width/2 + 170, Screen.height/2 + 50, 800,300), "난이도 : "+level);
    }
        
}
