using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Result : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
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
}
