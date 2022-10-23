using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None; 
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

}
