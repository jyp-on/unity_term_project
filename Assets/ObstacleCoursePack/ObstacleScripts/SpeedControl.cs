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
    
    public float movableObsWidthSpeed;
    public float movableObsWidthMaxSpeed;

    public float pendulumSpeed;
    public float pendulumMaxSpeed;
    
    public float rotatorSpeed;
    public float rotatorMaxSpeed;

    void Awake()
    {
        //200�ʱ��� ��� ��ֹ� ���������� �����ϵ��� ����.

        bridgeSphereSpeed = 4f;
        bridgeSphereMaxSpeed = 12f;

        //������ֹ��� ���̻� �ǵ��� ����. boat speed�� ��������.
        flyingObstaclespeed = 0.6f;
        flyingObstacleMaxspeed = 1.2f;
        flyingObstacleDownPower = 1.80f;
        flyingObstacleMaxDownPower = 1.85f;

        movableObsHeightSpeed = 250f;
        movableObsHeightMaxSpeed = 1250f;

        movableObsWidthSpeed = 250f;
        movableObsWidthMaxSpeed = 1250f;

        pendulumSpeed = 100f;
        pendulumMaxSpeed = 140f;

        rotatorSpeed = 1f;
        rotatorMaxSpeed = 5f;
    }

    void Start()
    {
        StartCoroutine(BridgeSphereSpeedUp());
        StartCoroutine(FlyingObstacleSpeedUp());
        StartCoroutine(FlyingObstacleDownPowerUp());
        StartCoroutine(movableObsHeightSpeedUp());
        StartCoroutine(MovableObsWidthSpeedUp());
        StartCoroutine(PendulumSpeedUp());
        StartCoroutine(RotatorSpeedUp());
    }

    IEnumerator BridgeSphereSpeedUp()
    {
        while(true)
        {
            if(bridgeSphereSpeed >= bridgeSphereMaxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            bridgeSphereSpeed += 0.4f;
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

            yield return new WaitForSeconds(10.0f);
            movableObsHeightSpeed += 50f;
        }
    }

    IEnumerator MovableObsWidthSpeedUp()
    {
        while(true)
        {
            if(movableObsWidthSpeed >= movableObsWidthMaxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            movableObsWidthSpeed += 50;
        }
    }

    IEnumerator PendulumSpeedUp()
    {
        while(true)
        {
            if(pendulumSpeed >= pendulumMaxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            pendulumSpeed += 2.0f;
        }
    }

    IEnumerator RotatorSpeedUp()
    {
        while(true)
        {
            if(rotatorSpeed >= rotatorMaxSpeed)
                yield break;

            yield return new WaitForSeconds(10.0f);
            rotatorSpeed += 0.2f;
        }
    }
}
