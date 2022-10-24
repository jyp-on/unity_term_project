using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FailCheck : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -3.0f)
            Fail();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Obstacle")
        {
            Fail();
        }
    }

    void Fail()
    {
        SceneManager.LoadScene("Result");
    }
}
