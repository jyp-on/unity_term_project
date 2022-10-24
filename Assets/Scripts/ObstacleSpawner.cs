using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] pf_Obstacle;
    public float interval = 5.0f;
    IEnumerator Start()
    {
        while(true)
        {
            int rand_num = Random.Range(0, 6);
            GameObject pf_Ob = Instantiate(pf_Obstacle[rand_num], this.transform.position, pf_Obstacle[rand_num].transform.rotation);

            Destroy(pf_Ob, 10.0f);
            yield return new WaitForSeconds(interval);
        }
    }
}
