using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FailCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -3.0f)
            Fail();
    }
    void Fail()
    {
        SceneManager.LoadScene("Result");
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Obstacle")
        {
            Fail();
        }
    }
}
