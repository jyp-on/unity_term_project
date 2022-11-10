using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class FailCheck : MonoBehaviour
{
  TextMeshProUGUI HpText;
  public AudioSource CollisionSound;
  public AudioSource HealSound;
  private GuiControl guiControl;
  private int current_score;
  private int best_score;
  private bool isDelay = false;
  private float delayTime = 0.0f;

  //
  [SerializeField]
  private Slider hp;
  private float max_hp = 100;
  private float current_hp = 100;
  private float temp;
  void Awake()
  {
    HpText = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
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
    DelayControl();
    HpText.text = current_hp + "/" + max_hp;
  }

  private void DelayControl()
  {
    if(isDelay == true)
    {
      delayTime += Time.deltaTime;
      if(delayTime > 1.0f) isDelay = false;
    }
  }

  private void HandleHp()
  {
    hp.value = Mathf.Lerp(hp.value, temp, Time.deltaTime * 3);
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "FailCheck") Fail(); //보트 옆면에 닿았을때.

    if (other.gameObject.tag == "Obstacle"  && !isDelay)
    { //player hp 감소
      isDelay = true;
      CollisionSound.Play();
      if (current_hp > 0) current_hp -= 20;
      
      temp = (float)current_hp / (float)max_hp;
    }

    if (other.gameObject.tag == "FlyingObstacle"  && !isDelay)
    { //player hp 감소
      isDelay = true;
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
