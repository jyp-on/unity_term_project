using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] pf_item;

    IEnumerator Start()
    {   
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(8f, 13f));
            int pf_num = Random.Range(0, 3);

            float rand_x = Random.Range(-3.0f, 3.0f);
            float rand_y = Random.Range(3.0f, 5.0f);

            GameObject pf_Ob = Instantiate(
            pf_item[pf_num], 
            new Vector3(this.transform.position.x + rand_x, this.transform.position.y + rand_y, this.transform.position.z),
            pf_item[pf_num].transform.rotation);
            
        }
    }
}
