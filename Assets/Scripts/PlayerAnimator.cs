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
        if(hAxis != 0 || vAxis != 0) isArrowKeyDown = true; //����Ű�� �ϳ��� ������������ true
        if(hAxis == 0 && vAxis == 0) isArrowKeyDown = false; //����Ű�� �ϳ��� ������������ true

        anim.SetBool("isIdle", !Input.anyKey);
        anim.SetBool("isWalk", !Input.GetKey(runningKey) && isArrowKeyDown); //Shift ������ �ʰ� �Ű�� ������������.
        anim.SetBool("isRun", Input.GetKey(runningKey) && isArrowKeyDown);
    }
}
