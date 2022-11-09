using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacle : MonoBehaviour
{
    private GameObject player;
    SpeedControl speedControl;
    // Start is called before the first frame update
    private float speed; //보트속도가 점점빨라져서 더 밑을 향하게 해야함.
    private float downPower;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Controller");
        speedControl = GameObject.Find("GameManager").GetComponent<SpeedControl>();
        speed = speedControl.flyingObstaclespeed;
        downPower = speedControl.flyingObstacleDownPower;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;

        player = GameObject.FindGameObjectWithTag("Controller");
        transform.position = Vector3.Lerp(transform.position, player.transform.position + (Vector3.down * downPower), speed * Time.deltaTime);
        if(transform.position.z < player.transform.position.z - 1f)  Destroy(this.gameObject);

    }
}
