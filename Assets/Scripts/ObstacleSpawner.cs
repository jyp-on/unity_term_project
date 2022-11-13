using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private GuiControl guiControl;
    public GameObject[] pf_Obstacle;
    public float interval = 5.0f;
    public float game_level;

    private float delayTime;
    
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
            if(rand_num == 4)
            {
                GameObject pf_Ob = Instantiate(pf_Obstacle[rand_num], 
                new Vector3(pf_Obstacle[rand_num].transform.position.x, pf_Obstacle[rand_num].transform.position.y, this.transform.position.z),
                pf_Obstacle[rand_num].transform.rotation);
                Destroy(pf_Ob, 12.0f);
            }
            else
            {
                GameObject pf_Ob = Instantiate(pf_Obstacle[rand_num], 
                new Vector3(this.transform.position.x + rand_x, pf_Obstacle[rand_num].transform.position.y, this.transform.position.z),
                pf_Obstacle[rand_num].transform.rotation);
                Destroy(pf_Ob, 12.0f);
            }

            
            yield return new WaitForSeconds(interval);
        }
        
    }
    void Update()
    {
        game_level = guiControl.level;
        
        if(game_level < 5) interval = 5f;
        else if(game_level < 10) interval = Random.Range(5f, 6f);
        else if(game_level < 15) interval = Random.Range(4f, 5f);
        else if(game_level < 20) interval = Random.Range(3.5f, 4f);
        else if(game_level < 25) interval = Random.Range(3f, 3.5f);
        else if(game_level < 30) interval = Random.Range(2.8f, 3f);
        else if(game_level < 35) interval = Random.Range(2f, 2.8f);
        else if(game_level < 40) interval = Random.Range(1.5f, 2f);
        else interval = 1.5f; //최대난이도 40

    }
}
