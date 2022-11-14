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

//Hp �� Stamina ���� �κ�.
  TextMeshProUGUI HpText;
  TextMeshProUGUI StaminaText;

  [SerializeField]
  private Slider hp;
  private float max_hp = 100;
  private float current_hp = 100;
  private float temp_hp; //Lerp�� �̿��� õõ�� �پ��°�ó�� ���̱� ���� ���� ����.
  
  [SerializeField]
  private Slider stamina;
  private float max_stamina = 100;
  private float current_stamina = 100; //ĳ������ static ������ �̿��Ͽ� ������ ��.
  
  private float temp_stamina = 100; //Lerp�� �̿��� õõ�� �پ��°�ó�� ���̱� ���� ���� ����.
  public float invincible_time; //????
  public static bool isInvincible = false;//????
 
  void Awake()
  {
    

    HpText = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
    StaminaText = GameObject.Find("Stamina").GetComponent<TextMeshProUGUI>();

    guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();

    hp.value = 1;
    temp_hp = (float)current_hp / (float)max_hp;

    current_stamina = FirstPersonMovement.current_stamina; //�÷��̾� ������ ��ũ��Ʈ���� ���� ���׹̳� ������.
    temp_stamina = FirstPersonMovement.temp_stamina;

    stamina.value = 1;
    
  }
  // Update is called once per frame
  void Update()
  {
    if (this.transform.position.y < -5f) Fail();

    if (current_hp <= 0) Fail();

    HpText.text = current_hp + "/" + max_hp;

    current_stamina = FirstPersonMovement.current_stamina; //�÷��̾� ������ ��ũ��Ʈ���� ���� ���׹̳� ������.
    temp_stamina = FirstPersonMovement.temp_stamina;

    StaminaText.text = (int)current_stamina + "/" + max_stamina;

    HandleHp();
    HandleStamina();
    InvincibleCount();
    
  }

  private void InvincibleCount()
  {
    if(isInvincible) invincible_time += Time.deltaTime;
      
    if(invincible_time > 1f) isInvincible = false;
  }

  private void HandleHp()
  {
    hp.value = Mathf.Lerp(hp.value, temp_hp, Time.deltaTime * 3);
  }

  private void HandleStamina()
  {
    stamina.value = Mathf.Lerp(stamina.value, FirstPersonMovement.temp_stamina, Time.deltaTime * 3);
    
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Obstacle" && !isInvincible)
    { //player hp ����
      CollisionSound.Play();
      isInvincible = true; //1?? ??.
      invincible_time = 0;

      if (other.gameObject.name == "Ball")
      {
        if (current_hp > 0) current_hp -= 30;
      
        temp_hp = (float)current_hp / (float)max_hp;
      }
      else
      {
        if (current_hp > 0) current_hp -= 20;
      
        temp_hp = (float)current_hp / (float)max_hp;
      }
      
    }

    if (other.gameObject.tag == "FlyingObstacle" && !isInvincible)
    { //player hp ����
      isInvincible = true; //1?? ??.
      invincible_time = 0;
      CollisionSound.Play();
      if (current_hp > 0) current_hp -= 10;
      
      temp_hp = (float)current_hp / (float)max_hp;
      
    } 

    
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Heal")
    { //player hp ����
      HealSound.Play();
      current_hp += 10;
      if(current_hp > 100) current_hp = 100;

      temp_hp = (float)current_hp / (float)max_hp;
      Destroy(other.gameObject);
    }  

    if (other.gameObject.tag == "Bomb")
    { //��ֹ�? ��ü �ı�
      // HealSound.Play();

      GameObject [] obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
      GameObject [] flyingObstacle = GameObject.FindGameObjectsWithTag("FlyingObstacle");

      GameObject boom = other.transform.Find("Explosion").gameObject;
      boom.transform.parent = null;
      boom.transform.parent = GameObject.FindGameObjectWithTag("Boat").transform;
      boom.transform.localScale = new Vector3(10,10,10);
      boom.transform.position += new Vector3(0, 3, 5);
      boom.SetActive(true);
      Destroy(other.gameObject);
      Destroy(boom.gameObject, 1f);
      foreach(GameObject ob in obstacle)  Destroy(ob);
      foreach(GameObject ob in flyingObstacle)  Destroy(ob);

    }  

    if(other.gameObject.tag == "Stamina")
    {
      HealSound.Play();

      FirstPersonMovement.current_stamina += 20;
      if(FirstPersonMovement.current_stamina > 100) FirstPersonMovement.current_stamina = 100;
      FirstPersonMovement.temp_stamina = (float) FirstPersonMovement.current_stamina / 100f;
      
      Destroy(other.gameObject);
    }
  }

  void Fail()
  {
    FirstPersonMovement.current_stamina = 100; //static �����̶� �ʱ�ȭ�ʿ�.
    FirstPersonMovement.temp_stamina = 100;

    PlayerPrefs.SetInt("current_score", (int)GuiControl.current_score);
    PlayerPrefs.SetInt("level", guiControl.level);

    current_score = PlayerPrefs.GetInt("current_score");
    best_score = PlayerPrefs.GetInt("best_score", 0); //�ְ������� ���ٸ� 0������ 

    if (current_score > best_score)
    {
      PlayerPrefs.SetInt("best_score", current_score);
    }
    current_score = 0;
    SceneManager.LoadScene("Result");
  }
}
