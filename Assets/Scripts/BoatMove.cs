using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    private float speed = 4f;
    private float max_speed = 8f;
    void Awake()
    {
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator SpeedUp()
    {
        while(true)
        {
            if(speed >= max_speed)
                yield break;

            yield return new WaitForSeconds(5.0f);
            speed += 1;
        }
    }
}
