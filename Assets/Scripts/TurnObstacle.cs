using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObstacle : MonoBehaviour
{
    private float rorate_speed;

    void Awake()
    {
        rorate_speed = Random.Range(15.0f, 40.0f);
    }
    void Update()
    {
        this.transform.Rotate(Vector3.up * rorate_speed * Time.deltaTime);
    }
}
