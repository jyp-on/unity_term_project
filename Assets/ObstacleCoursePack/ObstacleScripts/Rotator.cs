using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	private float speed = 1f;
    private float maxSpeed = 3f;

    void Update()
    {
		  transform.Rotate(0f, 0f, -1 * speed * Time.deltaTime / 0.01f, Space.Self);
	}

    IEnumerator SpeedUp()
    {
        while(true)
        {
            if(speed >= maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            speed += 0.5f;
        }
    }

}
