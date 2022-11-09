using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float speed = 1f;
    public float maxSpeed = 3f;

    void Update()
    {
		  transform.Rotate(0f, 0f, -1 * speed * Time.deltaTime / 0.01f, Space.Self);
	}

    

}
