using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
  SpeedControl speedControl;
  public float speed = 100f;
  public float maxSpeed = 120f;

  // Start is called before the first frame update
  void Awake()
  {
		this.transform.rotation = Quaternion.Euler(0, 0 , Random.Range(-90f, 90f));
  }

  // Update is called once per frame
  void Update()
  {
    float angle = Mathf.Sin(Time.time);
    transform.localRotation = Quaternion.Euler(0, 0, angle * speed);
  }

  
}