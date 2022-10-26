using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public float speed = 5.0f;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Q) && this.transform.position.x > -3.0f)
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.E) && this.transform.position.x < 3.0f)
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    IEnumerator SpeedUp()
    {
        while(true)
        {
            speed += 1;
            yield return new WaitForSeconds(10.0f);
        }
    }
}
