using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    public Material normal;
    public Material invincible;
    void Update()
    {
        if(FailCheck.isInvincible) gameObject.GetComponent<MeshRenderer>().material = invincible;//�����̸�
        else gameObject.GetComponent<MeshRenderer>().material = normal;
    }
}

