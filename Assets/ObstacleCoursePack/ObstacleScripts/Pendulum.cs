using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
  SpeedControl speedControl;
  private float speed;

  // Start is called before the first frame update
  void Awake()
  {
    speedControl = GameObject.Find("GameManager").GetComponent<SpeedControl>();
    speed = speedControl.pendulumSpeed;
		this.transform.rotation = Quaternion.Euler(0, 0 , Random.Range(-90f, 90f));
  }

  // Update is called once per frame
  void Update()
  {
    float angle = Mathf.Sin(Time.time);
    transform.localRotation = Quaternion.Euler(0, 0, angle * speed);
  }

  
}