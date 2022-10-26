using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GuiControl control;
    public MovableObs movableObs;
    public Pendulum pendulum;
    public Rotator rotator;
    public WallMovable wallMovable;
    
    public float power = 7.0f;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(LevelUp());
    }

    // Update is called once per frame
    IEnumerator LevelUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(5.0f);

            movableObs.speed += power;
            pendulum.speed += (power*2);
            rotator.speed += (power/3);
            wallMovable.speed += power;
        }
    }
}
