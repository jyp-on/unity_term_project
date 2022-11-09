using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacle : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    private float speed = 2f; //보트속도가 점점빨라져서 더 밑을 향하게 해야함.
    private float maxSpeed = 2f;
    private int downPower = 1;
    private int maxDownPower = 3;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Controller");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;

        player = GameObject.FindGameObjectWithTag("Controller");
        transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
        if(transform.position.z < player.transform.position.z - 1f)  Destroy(this.gameObject);

    }

    IEnumerator SpeedUp()
    {
        while(true)
        {
            if(speed >= maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            speed += 1f;
            downPower += 1;
        }
    }

    IEnumerator DownPowerUp()
    {
        while(true)
        {
            if(downPower >= maxDownPower)
                yield break;

            yield return new WaitForSeconds(10.0f);
            downPower += 1;
        }
    }
}
