using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
  private float speed = 100f;
  private float maxSpeed = 120f;

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

  IEnumerator SpeedUp()
    {
        while(true)
        {
            if(speed >= maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            speed += 5;
        }
    }
}