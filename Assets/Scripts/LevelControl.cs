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
    public int current_level = 0;
    public int max_level = 5;

    
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
            current_level += 1;
            if(current_level < max_level)
            {
                movableObs.speed += power;
                pendulum.speed += (power*2);
                rotator.speed += (power/3);
                wallMovable.speed += power;
            }
            
        }
    }
}
