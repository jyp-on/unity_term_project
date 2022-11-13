using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static Animator anim;
    float hAxis;
    float vAxis;
    // Start is called before the first frame update
    private bool isArrowKeyDown;
    private KeyCode runningKey = KeyCode.LeftShift;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal"); 
        vAxis = Input.GetAxisRaw("Vertical");
        if(hAxis != 0 || vAxis != 0) isArrowKeyDown = true; //방향키를 하나라도 누르고있으면 true
        if(hAxis == 0 && vAxis == 0) isArrowKeyDown = false; //방향키를 하나라도 누르고있으면 true

        anim.SetBool("isIdle", !Input.anyKey);
        anim.SetBool("isWalk", !Input.GetKey(runningKey) && isArrowKeyDown); //Shift 누르지 않고 어떤키를 누르고있을때.
        anim.SetBool("isRun", Input.GetKey(runningKey) && isArrowKeyDown);
    }
}
