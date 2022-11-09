using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacle : MonoBehaviour
{
    private GameObject player;
    private GuiControl guiControl;
    // Start is called before the first frame update
    private float downPower = 1; //보트속도가 점점빨라져서 더 밑을 향하게 해야함.
    private int maxLevel = 8; //보트 최대속도
    void Awake()
    {
        guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
        player = GameObject.FindGameObjectWithTag("Controller");
        if(guiControl.level < maxLevel) downPower = (guiControl.level * 10f);
        else downPower = (maxLevel * 10f);
    }

    // Update is called once per frame
    void Update()
    {
        

        player = GameObject.FindGameObjectWithTag("Controller");
        Vector3 speed = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position
        , player.transform.position + (Vector3.down * downPower * Time.deltaTime * 3), 
        ref speed, 0.07f);

        if(transform.position.z < player.transform.position.z -1.5)  Destroy(this.gameObject);

    }
}
