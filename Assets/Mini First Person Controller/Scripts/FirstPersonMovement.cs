using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public AudioSource small;
    public AudioSource thin;
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 8;
    public KeyCode runningKey = KeyCode.LeftShift;
    private GameObject body;
    private GameObject controller;
    private CapsuleCollider capCol;
    private GameObject boat;
    private bool isSmallKeyDown;
    private bool isThinKeyDown;
    
    new Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        boat = GameObject.FindGameObjectWithTag("Boat");
        controller = GameObject.FindGameObjectWithTag("Controller");
    }
    void Update()
    {
        Small();
        Thin();
        

        if(isSmallKeyDown || isThinKeyDown){
            speed = 2f;
            runSpeed = 3f;
        }
        else{
            speed = 5f;
            runSpeed = 8f;
        }


    }


    void Small()
    {
        //세로로 작아지기
        if(Input.GetMouseButtonDown(0) && !isSmallKeyDown){
            controller.transform.localScale = new Vector3(this.transform.localScale.x, 0.05f, this.transform.localScale.z);
            isSmallKeyDown = true;
            small.Play();
        }

        if(Input.GetMouseButtonUp(0)){
            controller.transform.localScale = new Vector3(this.transform.localScale.x, 0.1f, this.transform.localScale.z);
            isSmallKeyDown = false;
        }
    }

    void Thin()
    {
        if(Input.GetMouseButtonDown(1) && !isThinKeyDown){
            controller.transform.localScale = new Vector3(0.05f, this.transform.localScale.y, this.transform.localScale.z);
            controller.GetComponent<CapsuleCollider>().radius = 0.3f;
            isThinKeyDown = true;
            thin.Play();
        }

        if(Input.GetMouseButtonUp(1)){
            controller.transform.localScale = new Vector3(0.1f, this.transform.localScale.y, this.transform.localScale.z);
            controller.GetComponent<CapsuleCollider>().radius = 0.5f;
            isThinKeyDown = false;
        }
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }

    // void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.tag == "Boat"){ //보트에 발을 대면
    //         this.transform.parent = boat.transform;
    //     }
    //     else{
    //         this.transform.parent = null; //다른물체에 발 닿으면
    //     }
    // }

    // void OnCollisionExit(Collision other) {
    //     if(other.gameObject.tag == "Boat"){ //보트에서 발을 때면 
    //         this.transform.parent = null;
    //     }
    // }
}