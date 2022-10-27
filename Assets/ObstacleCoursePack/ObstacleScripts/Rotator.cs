using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private GuiControl guiControl;
	public float speed = 1f;


    void Awake()
    {
        guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
        speed += (guiControl.level / 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
		  transform.Rotate(0f, 0f, -1 * speed * Time.deltaTime / 0.01f, Space.Self);
	  }
}
