using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    SpeedControl speedControl;
	private float speed;

    void Awake()
    {
        speedControl = GameObject.Find("GameManager").GetComponent<SpeedControl>();
        speed = speedControl.rotatorSpeed;
    }
    void Update()
    {
		transform.Rotate(0f, 0f, -1 * speed * Time.deltaTime / 0.01f, Space.Self);
	}
}
