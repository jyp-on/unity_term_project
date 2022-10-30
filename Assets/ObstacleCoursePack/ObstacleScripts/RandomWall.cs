using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWall : MonoBehaviour
{
    public GameObject ob1;
    public GameObject ob2;
    void Awake()
    {
        ob1.transform.Translate(Vector3.up * (Random.Range(0f, 2.0f)));
        ob2.transform.Translate(Vector3.up * (Random.Range(0f, 2.0f)));
    }
}
