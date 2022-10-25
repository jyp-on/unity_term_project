using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FailCheck : MonoBehaviour
{   
    private GuiControl guiControl;

    private int current_score;
    private int best_score;
    
    void Awake()
    {
        guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
    }
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -3.0f)
            Fail();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Obstacle")
        {
            Fail();
        }
    }

    void Fail()
    {
        PlayerPrefs.SetInt("current_score", (int)guiControl.current_time);
        PlayerPrefs.SetInt("level", guiControl.level);

        current_score = PlayerPrefs.GetInt("current_score");
        best_score = PlayerPrefs.GetInt("best_score");

        if(current_score > best_score){
            PlayerPrefs.SetInt("best_score", current_score);
        }

        SceneManager.LoadScene("Result");
    }
}
