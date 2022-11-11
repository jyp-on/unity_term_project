using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public AudioSource small;
    public AudioSource thin;
    public float speed = 5;
    public bool canRun = true;
    public float runSpeed = 8;
    public KeyCode runningKey = KeyCode.LeftShift;
    private GameObject body;
    private GameObject controller;
    private CapsuleCollider capCol;
    private GameObject boat;
    private bool isSmallKeyDown;
    private bool isThinKeyDown;

    public static float current_stamina = 100; // 스태미나. FilCheck 스크립트로 넘겨야함.
    public static float temp_stamina = 100; //Lerp를 이용해 천천히 줄어드는것처럼 보이기 위해 만든 변수.

    private bool staminaIncreaseable = true; //뛰고나서 잠시동안 증가하지 못하게 하기위해 만든 변수.
    private float staminaDelay;
    
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
        SpeedCheck(); //달릴때 속도 조절.
        StaminaUp(); //스테미나 증가
        RunStaminaDown(); //달릴때 스테미나 감소.
        
    }

    void StaminaUp()
    {
        if (current_stamina < 100 && staminaIncreaseable) //달리지 않아야 스테미나 차도록.
        {
            current_stamina += 1f * Time.deltaTime;
            temp_stamina = (float)current_stamina / 100;
        }
    }

    void RunStaminaDown()
    {
        if (Input.GetKey(runningKey) && canRun)
        {
            current_stamina -= 5f * Time.deltaTime;
            temp_stamina = (float)current_stamina / 100;
        }
    }

    void Small()
    {
        //세로로 작아지기
        if(Input.GetMouseButtonDown(0) && !isSmallKeyDown && current_stamina >= 10){
            current_stamina -= 10f;
            if(current_stamina < 0) current_stamina = 0;
            temp_stamina = (float)current_stamina / 100;
            controller.transform.localScale = new Vector3(this.transform.localScale.x, 0.3f, this.transform.localScale.z);
            isSmallKeyDown = true;
            small.Play();
        }

        if(Input.GetMouseButtonUp(0)){
            controller.transform.localScale = new Vector3(this.transform.localScale.x, 1.1f, this.transform.localScale.z);
            isSmallKeyDown = false;
        }
    }

    void Thin()
    {
        if(Input.GetMouseButtonDown(1) && !isThinKeyDown && current_stamina >= 10){
            current_stamina -= 10f;
            if(current_stamina < 0) current_stamina = 0;
            temp_stamina = (float)current_stamina / 100;
            controller.transform.localScale = new Vector3(0.3f, this.transform.localScale.y, this.transform.localScale.z);
            Debug.Log(controller.transform.localScale);
            controller.GetComponent<CapsuleCollider>().radius = 0.3f;
            isThinKeyDown = true;
            thin.Play();
        }

        if(Input.GetMouseButtonUp(1)){
            controller.transform.localScale = new Vector3(1.1f, this.transform.localScale.y, this.transform.localScale.z);
            Debug.Log(controller.transform.localScale);
            controller.GetComponent<CapsuleCollider>().radius = 0.5f;
            isThinKeyDown = false;
        }
    }

    void SpeedCheck()
    {
        if(isSmallKeyDown || isThinKeyDown)
        {
            if(isSmallKeyDown && isThinKeyDown)
            {
                speed = 1f;
                runSpeed = 1.5f;
            }
            else
            {
                speed = 2f;
                runSpeed = 3f;
            }
        }
        else
        {
            speed = 5f;
            runSpeed = 8f;
        }
    }
    
    

    void FixedUpdate()
    {
        if(current_stamina < 1) canRun = false;
        else canRun = true;


        if(Input.GetKey(runningKey))  staminaDelay = 0;
        else staminaDelay += Time.deltaTime; //뛰지 않은시간 동안 Delay 늘어나게하고 특정 시간되면 변수 true로.

        if(staminaDelay >= 1f) staminaIncreaseable = true; //1초동안 뛰지 않아야 스테미나 증가할수 있도록.
        else staminaIncreaseable = false;

    
        // Get targetMovingSpeed.
        float targetMovingSpeed = (canRun && Input.GetKey(runningKey)) ? runSpeed : speed;
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