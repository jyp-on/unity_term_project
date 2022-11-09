using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPackSpawner : MonoBehaviour
{
    public GameObject pf_HealPack;

    IEnumerator Start()
    {   
        while(true)
        {
            yield return new WaitForSeconds(10.0f);

            float rand_x = Random.Range(-3.0f, 3.0f);
            float rand_y = Random.Range(0.0f, 3.0f);

            GameObject pf_Ob = Instantiate(
            pf_HealPack, 
            new Vector3(this.transform.position.x + rand_x, this.transform.position.y + rand_y, this.transform.position.z),
            pf_HealPack.transform.rotation);
            
        }
    }
}
