using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObsHeight : MonoBehaviour
{
  SpeedControl speedControl;
  private float speed;
  private int randomStartDirection;
  private bool isUp;

  void Awake()
  {
    speedControl = GameObject.Find("GameManager").GetComponent<SpeedControl>();
    speed = speedControl.movableObsHeightSpeed;
    Debug.Log(speed);
    randomStartDirection = Random.Range(0, 2);

    if (randomStartDirection == 0)
    {
      isUp = true;
    }
    else
    {
      isUp = false;
    }

    this.transform.position = new Vector3(this.transform.position.x, Random.Range(2.0f, 7.0f), this.transform.position.z);

  }

  // Update is called once per frame
  void Update()
  {
    if (this.transform.position.y < 2.0f) //아래쪽 닿으면 위로
      isUp = true;


    if (this.transform.position.y > 7.0f)  //위로 닿으면 아래로
      isUp = false;

    if (isUp)
    {
      this.transform.Translate(new Vector3(0, 0.01f * speed * Time.deltaTime, 0) );
    }
    else
    {
      this.transform.Translate(new Vector3(0, -0.01f * speed * Time.deltaTime, 0) );
    }
  }

  
}
