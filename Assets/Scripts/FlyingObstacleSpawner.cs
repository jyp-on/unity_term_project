using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacleSpawner : MonoBehaviour
{
    private GuiControl guiControl;
    public GameObject pf_Obstacle;
    // Start is called before the first frame update
    public float interval = 3.0f;

    private int cnt = 0;
    
    // Update is called once per frame
    void Awake()
    {
        guiControl = GameObject.Find("GameManager").GetComponent<GuiControl>();
    }

    void Update()
    {
        int game_level = guiControl.level;
        
        if(game_level < 5) cnt = 1;  
        else if(game_level < 10) cnt = 2;
        else if(game_level < 15) cnt = 3;
        else if(game_level < 20) cnt = 4;
        else if(game_level < 25) cnt = 5;
        else if(game_level < 30) cnt = 6;
        else if(game_level < 35) cnt = 7;
        else if(game_level < 40) cnt = 8;
        else if(game_level < 50) cnt = 9;
        else cnt = 10;
        
    }

    IEnumerator Start()
    {   
        while(true)
        {
            yield return new WaitForSeconds(interval);

            for(int i = 0; i < cnt; i++)
            {
                float rand_x = Random.Range(-30.0f, 30.0f);

                GameObject pf_Ob = Instantiate(
                pf_Obstacle, 
                new Vector3(this.transform.position.x + rand_x, this.transform.position.y, this.transform.position.z),
                this.transform.rotation);
            }
        }
    }
}
