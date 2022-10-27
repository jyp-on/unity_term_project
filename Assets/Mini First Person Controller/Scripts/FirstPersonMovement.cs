using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
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
        if(Input.GetMouseButtonDown(2) && !isSmallKeyDown){
            controller.transform.localScale = new Vector3(this.transform.localScale.x, 0.11f, this.transform.localScale.z);
            isSmallKeyDown = true;
        }

        if(Input.GetMouseButtonUp(2)){
            controller.transform.localScale = new Vector3(this.transform.localScale.x, 0.22f, this.transform.localScale.z);
            isSmallKeyDown = false;
        }

        if(isSmallKeyDown){
            speed = 1f;
            runSpeed = 3f;
        }
        else{
            speed = 5f;
            runSpeed = 8f;
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

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Boat"){ //보트에서 발을 때면 
            this.transform.parent = null;
        }
        else{
            this.transform.parent = boat.transform;
        }
    }
}