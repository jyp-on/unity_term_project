using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Awake()
    {
       Destroy(GameObject.Find("GameManager"));
    }
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Play");
    }
    public void OnClickGuide()
    {
        SceneManager.LoadScene("Guide");
    }
    public void onClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
