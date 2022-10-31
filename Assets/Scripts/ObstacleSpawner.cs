using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private GuiControl guiControl;
    public GameObject[] pf_Obstacle;
    public float interval = 5.0f;
    public float game_level;
    
    void Awake()
    {
        guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
    }

    IEnumerator Start()
    {   
        while(true)
        {
            int rand_num = Random.Range(0, 7);
            float rand_x = Random.Range(-2.0f, 2.0f);
            GameObject pf_Ob = Instantiate(pf_Obstacle[rand_num], 
            new Vector3(this.transform.position.x + rand_x, pf_Obstacle[rand_num].transform.position.y, this.transform.position.z),
             pf_Obstacle[rand_num].transform.rotation);

            Destroy(pf_Ob, 20.0f);
            yield return new WaitForSeconds(interval);
        }
    }
    void Update()
    {
        game_level = guiControl.level;
        
        if(game_level < 5)
        {
            interval = 4.0f;
        }
        else if(game_level < 10)
        {
            interval = 3.0f;
        }
        else if(game_level < 15)
        {
            interval = 2.0f;
        }
        else
        {
            interval = 1.0f;
        }
        
    }
}
