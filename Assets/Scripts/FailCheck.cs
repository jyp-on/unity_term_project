using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FailCheck : MonoBehaviour
{
  private GuiControl guiControl;
  private int current_score;
  private int best_score;

  //
  [SerializeField]
  private Slider hp;
  private float max_hp = 100;
  private float current_hp = 100;
  private float temp;
  void Awake()
  {
    guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
    hp.value = (float)current_hp / (float)max_hp;
    temp = (float)current_hp / (float)max_hp;
  }
  // Update is called once per frame
  void Update()
  {
    if (this.transform.position.y < -3.0f)
      Fail();

    HandleHp();

  }

  private void HandleHp()
  {

    hp.value = Mathf.Lerp(hp.value, temp, Time.deltaTime * 10);
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "FailCheck")
    {
      Fail();
    }

    if (other.gameObject.tag == "Obstacle")
    { //player hp ����
      if (current_hp > 0)
      {
        current_hp -= 20;
      }
      else
      {
        Fail();
      }
      temp = (float)current_hp / (float)max_hp;
    }
  }

  void Fail()
  {
    PlayerPrefs.SetInt("current_score", (int)guiControl.current_time);
    PlayerPrefs.SetInt("level", guiControl.level);

    current_score = PlayerPrefs.GetInt("current_score");
    best_score = PlayerPrefs.GetInt("best_score", 0); //�ְ������� ���ٸ� 0������ 

    if (current_score > best_score)
    {
      PlayerPrefs.SetInt("best_score", current_score);
    }

    SceneManager.LoadScene("Result");
  }
}
