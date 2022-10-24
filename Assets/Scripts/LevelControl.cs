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
    
    public float power = 10.0f;
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
            pendulum.speed += power;
            rotator.speed += power;
            wallMovable.speed += power;
        }
    }
}
