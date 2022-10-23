using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject pf_Obstacle;
    public float interval = 5.0f;
    IEnumerator Start()
    {
        while(true)
        {
            GameObject pf_Ob = Instantiate(pf_Obstacle, this.transform.position, this.transform.rotation);
            Destroy(pf_Ob, 7.0f);
            yield return new WaitForSeconds(interval);
        }
    }
}
