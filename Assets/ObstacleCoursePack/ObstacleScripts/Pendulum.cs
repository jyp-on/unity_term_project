using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
  private GuiControl guiControl;
  public float speed = 100f;

  // Start is called before the first frame update
  void Awake()
  {
    guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
		this.transform.rotation = Quaternion.Euler(0, 0 , Random.Range(-90f, 90f));
    speed += guiControl.level;
  }

  // Update is called once per frame
  void Update()
  {
    float angle = Mathf.Sin(Time.time);
    transform.localRotation = Quaternion.Euler(0, 0, angle * speed);
  }
}