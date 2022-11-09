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
        else cnt = 4;
    }

    IEnumerator Start()
    {   
        while(true)
        {
            yield return new WaitForSeconds(interval);

            for(int i = 0; i < cnt; i++)
            {
                float rand_x = Random.Range(-30.0f, 30.0f);
                float rand_y = Random.Range(-3.0f, 3.0f);

                GameObject pf_Ob = Instantiate(
                pf_Obstacle, 
                new Vector3(this.transform.position.x + rand_x, this.transform.position.y + rand_y, this.transform.position.z),
                this.transform.rotation);
            }
        }
    }
}
