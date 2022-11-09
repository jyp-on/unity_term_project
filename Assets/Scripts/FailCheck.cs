using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FailCheck : MonoBehaviour
{
  public AudioSource CollisionSound;
  public AudioSource HealSound;
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
    if (this.transform.position.y < -3.0f) Fail();

    if (current_hp <= 0) Fail();

    HandleHp();
  }

  private void HandleHp()
  {
    hp.value = Mathf.Lerp(hp.value, temp, Time.deltaTime * 10);
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "FailCheck") Fail(); //보트 옆면에 닿았을때.

    if (other.gameObject.tag == "Obstacle")
    { //player hp 감소
      CollisionSound.Play();
      if (current_hp > 0) current_hp -= 20;
      
      temp = (float)current_hp / (float)max_hp;
    }

    if (other.gameObject.tag == "FlyingObstacle")
    { //player hp 감소
      CollisionSound.Play();
      if (current_hp > 0) current_hp -= 10;
      
      temp = (float)current_hp / (float)max_hp;
    } 
  }

  void OnTriggerStay(Collider other) 
  {
    if (other.gameObject.tag == "HealPack")
    { //player hp 증가
      HealSound.Play();
      current_hp += 10;
      if(current_hp > 100) current_hp = 100;

      temp = (float)current_hp / (float)max_hp;
      Destroy(other.gameObject);
    }  
  }

  void OnGUI()
  {
      GUI.skin.label.fontSize = 60;
      GUI.Label(new Rect(Screen.width - 360, 40, 300,120), current_hp + "/" + max_hp);
  }

  void Fail()
  {
    PlayerPrefs.SetInt("current_score", (int)guiControl.current_time);
    PlayerPrefs.SetInt("level", guiControl.level);

    current_score = PlayerPrefs.GetInt("current_score");
    best_score = PlayerPrefs.GetInt("best_score", 0); //최고점수가 없다면 0점으로 

    if (current_score > best_score)
    {
      PlayerPrefs.SetInt("best_score", current_score);
    }

    SceneManager.LoadScene("Result");
  }
}
