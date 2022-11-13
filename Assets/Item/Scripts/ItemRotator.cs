using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    private float degeePerSecond = 120.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * degeePerSecond , Space.Self);
    }
}
