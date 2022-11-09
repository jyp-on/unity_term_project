using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    // BridgeSphere bridgeSphere;
    public float bridgeSphereSpeed;
    public float bridgeSphereMaxSpeed;

    public float flyingObstaclespeed;
    public float flyingObstacleMaxspeed;
    public float flyingObstacleDownPower;
    public float flyingObstacleMaxDownPower;


    public float movableObsHeightSpeed;
    public float movableObsHeightMaxSpeed;
    MovableObsWidth movableObsWidth;
    Pendulum pendulum;
    Rotator rotator;

    void Awake()
    {
        bridgeSphereSpeed = 4f;
        bridgeSphereMaxSpeed = 7f;

        flyingObstaclespeed = 0.6f;
        flyingObstacleMaxspeed = 1.2f;
        flyingObstacleDownPower = 1.80f;
        flyingObstacleMaxDownPower = 1.85f;

        movableObsHeightSpeed = 300f;
        movableObsHeightMaxSpeed = 500f;

    }

    void Start()
    {
        // StartCoroutine(BridgeSphereSpeedUp());
        StartCoroutine(FlyingObstacleSpeedUp());
        StartCoroutine(FlyingObstacleDownPowerUp());
        // StartCoroutine(movableObsHeightSpeedUp());
        // StartCoroutine(MovableObsWidthSpeedUp());
        // StartCoroutine(PendulumSpeedUp());
        // StartCoroutine(RotatorSpeedUp());
    }

    IEnumerator BridgeSphereSpeedUp()
    {
        while(true)
        {
            if(bridgeSphereSpeed >= bridgeSphereMaxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            bridgeSphereSpeed += 1f;
        }
    }

    IEnumerator FlyingObstacleSpeedUp()
    {
        while(true)
        {
            if(flyingObstaclespeed >= flyingObstacleMaxspeed)
            {
                flyingObstaclespeed = flyingObstacleMaxspeed;
                yield break;
            }
                

            yield return new WaitForSeconds(10.0f);
            flyingObstaclespeed += 0.1f;
        }
    }

    IEnumerator FlyingObstacleDownPowerUp()
    {
        while(true)
        {
            if(flyingObstacleDownPower >= flyingObstacleMaxDownPower)
            {
                flyingObstacleDownPower = flyingObstacleMaxDownPower;
                yield break;
            }
                

            yield return new WaitForSeconds(15.0f);
            flyingObstacleDownPower += 0.01f;
        }
    }

    IEnumerator movableObsHeightSpeedUp()
    {
        while(true)
        {
            if(movableObsHeightSpeed >= movableObsHeightMaxSpeed)
                yield break;

            yield return new WaitForSeconds(5.0f);
            movableObsHeightSpeed += 20f;
        }
    }

    IEnumerator MovableObsWidthSpeedUp()
    {
        while(true)
        {
            if(movableObsWidth.speed >= movableObsWidth.maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            movableObsWidth.speed += 20;
        }
    }

    IEnumerator PendulumSpeedUp()
    {
        while(true)
        {
            if(pendulum.speed >= pendulum.maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            pendulum.speed += 5;
        }
    }

    IEnumerator RotatorSpeedUp()
    {
        while(true)
        {
            if(rotator.speed >= rotator.maxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            rotator.speed += 0.5f;
        }
    }
}
