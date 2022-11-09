using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSphere : MonoBehaviour
{
    private float speed = 5f;
    private float maxSpeed = 8f;
    private bool isRight;
    private int randomStartDirection; //right 0, left 1
    void Awake()
    {
        randomStartDirection = Random.Range(0, 2);

        if(randomStartDirection == 0){
            isRight = true;
        }
        else{
            isRight = false;
        }

        this.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), this.transform.position.y, this.transform.position.z);  
    }

    // Update is called once per frame
    void Update()
    {

        if(this.transform.position.x < -7.0f) //�������� ������ ���������� ��������.
            isRight = true;
            

        if(this.transform.position.x > 7.0f)  //���������� ���� ���  
            isRight = false;
        
        if(isRight)
        {
            this.transform.Translate(Vector3.right  * speed * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(Vector3.left  * speed * Time.deltaTime);
        }
            
            
    }

    IEnumerator SpeedUp()
    {
        while(true)
        {
            if(speed >= maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            speed += 1f;
        }
    }
}
