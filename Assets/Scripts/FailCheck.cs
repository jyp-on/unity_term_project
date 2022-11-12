using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class FailCheck : MonoBehaviour
{
  public AudioSource CollisionSound;
  public AudioSource HealSound;
  private GuiControl guiControl;

  private int current_score;
  private int best_score;

//Hp 및 Stamina 관리 부분.
  TextMeshProUGUI HpText;
  TextMeshProUGUI StaminaText;

  [SerializeField]
  private Slider hp;
  private float max_hp = 100;
  private float current_hp = 100;
  private float temp_hp; //Lerp를 이용해 천천히 줄어드는것처럼 보이기 위해 만든 변수.
  
  [SerializeField]
  private Slider stamina;
  private float max_stamina = 100;
  private float current_stamina = 100; //캐릭터의 static 변수를 이용하여 가져올 것.
  
  private float temp_stamina = 100; //Lerp를 이용해 천천히 줄어드는것처럼 보이기 위해 만든 변수.
 
  void Awake()
  {
    

    HpText = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
    StaminaText = GameObject.Find("Stamina").GetComponent<TextMeshProUGUI>();

    guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();

    hp.value = 1;
    temp_hp = (float)current_hp / (float)max_hp;

    current_stamina = FirstPersonMovement.current_stamina; //플레이어 움직임 스크립트에서 현재 스테미나 가져옴.
    temp_stamina = FirstPersonMovement.temp_stamina;

    stamina.value = 1;
    
  }
  // Update is called once per frame
  void Update()
  {
    if (this.transform.position.y < -5f) Fail();

    if (current_hp <= 0) Fail();

    HpText.text = current_hp + "/" + max_hp;

    current_stamina = FirstPersonMovement.current_stamina; //플레이어 움직임 스크립트에서 현재 스테미나 가져옴.
    temp_stamina = FirstPersonMovement.temp_stamina;

    StaminaText.text = (int)current_stamina + "/" + max_stamina;

    HandleHp();
    HandleStamina();
  }

  private void HandleHp()
  {
    hp.value = Mathf.Lerp(hp.value, temp_hp, Time.deltaTime * 3);
  }

  private void HandleStamina()
  {
    stamina.value = Mathf.Lerp(stamina.value, temp_stamina, Time.deltaTime * 3);
    
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "FailCheck") Fail(); //보트 옆면에 닿았을때.

    if (other.gameObject.tag == "Obstacle")
    { //player hp 감소
      CollisionSound.Play();
      if (current_hp > 0) current_hp -= 20;
      
      temp_hp = (float)current_hp / (float)max_hp;
    }

    if (other.gameObject.tag == "FlyingObstacle")
    { //player hp 감소
      CollisionSound.Play();
      if (current_hp > 0) current_hp -= 10;
      
      temp_hp = (float)current_hp / (float)max_hp;
    } 
  }

  void OnTriggerStay(Collider other) 
  {
    if (other.gameObject.tag == "HealPack")
    { //player hp 증가
      HealSound.Play();
      current_hp += 10;
      if(current_hp > 100) current_hp = 100;

      temp_hp = (float)current_hp / (float)max_hp;
      Destroy(other.gameObject);
    }  
  }

  void Fail()
  {
    FirstPersonMovement.current_stamina = 100; //static 영역이라 초기화필요.
    FirstPersonMovement.temp_stamina = 100;

    PlayerPrefs.SetInt("current_score", (int)GuiControl.current_score);
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
