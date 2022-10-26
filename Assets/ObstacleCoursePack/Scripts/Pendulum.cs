using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
	private GuiControl guiControl;
	public float speed = 100f;
	
	// public float limit = 75f; //Limit in degrees of the movement
	public bool randomStart = true; //If you want to modify the start position
	private float random = 0;

	// Start is called before the first frame update
	void Awake()
    {
			guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
      speed += guiControl.level;
			if(randomStart)
				random = Random.Range(0f, 1f);
		}

    // Update is called once per frame
    void Update()
    {
			float angle =  Mathf.Sin(Time.time + random);
			transform.localRotation = Quaternion.Euler(0, 0, angle * speed);
		}
}
