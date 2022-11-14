using UnityEngine;

public class Jump : MonoBehaviour
{
    public AudioSource audioSource;
    new Rigidbody rigidbody;
    public float jumpStrength = 4;
    public static int jumpCount; //점프했는지 여부
    public float jumpTime;
    private bool isSuperJump = false;
    
    Animator anim;

    void Start()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
        anim = PlayerAnimator.anim; //Awake로 하면 anim 못가져옴 (null point exception)
    }

    void Update()
    {
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (jumpCount<2)) //2단점프까지 가능.
        {
            jumpCount += 1;
            rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            
            audioSource.Play();
        }

        if(Input.GetMouseButtonDown(2) && !isSuperJump && FirstPersonMovement.current_stamina > 20f)
        {
            isSuperJump = true;
            rigidbody.AddForce(Vector3.up * jumpStrength * 2, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");

            FirstPersonMovement.current_stamina -= 20f;
            FirstPersonMovement.temp_stamina = (float) FirstPersonMovement.current_stamina / 100f;
            
            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision other) {
        // if(other.gameObject.tag == "Boat")
        // {
            jumpCount = 0;
            isSuperJump = false;
            anim.SetBool("isJump", false);
        // }
    }
}
