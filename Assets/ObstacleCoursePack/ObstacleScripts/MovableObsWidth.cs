﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObsWidth : MonoBehaviour
{
  private float speed = 300f;
  private float maxSpeed = 500f;
  private int randomStartDirection;
  private bool isRight;

  void Awake()
  { 
    randomStartDirection = Random.Range(0, 2);

    if (randomStartDirection == 0)
    {
      isRight = true;
    }
    else
    {
      isRight = false;
    }

    this.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), this.transform.position.y, this.transform.position.z);

    
  }

  // Update is called once per frame
  void Update()
  {
    if (this.transform.position.x < -7.0f) //왼쪽으로 나가면 오른쪽으로 돌려야함.
      isRight = true;


    if (this.transform.position.x > 7.0f)  //오른쪽으로 나갈 경우  
      isRight = false;

    if (isRight)
    {
      this.transform.Translate(new Vector3(0.01f * speed * Time.deltaTime, 0, 0));
    }
    else
    {
      this.transform.Translate(new Vector3(-0.01f * speed * Time.deltaTime, 0, 0));
    }
  }

  IEnumerator SpeedUp()
    {
        while(true)
        {
            if(speed >= maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            speed += 20;
        }
    }
}
