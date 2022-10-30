using UnityEngine;

public class Jump : MonoBehaviour
{
    public AudioSource audioSource;
    new Rigidbody rigidbody;
    public float jumpStrength = 4;
    public int jumpCount; //점프했는지 여부
    public float jumpTime;

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (jumpCount<2)) //2단점프까지 가능.
        {
            jumpCount += 1;
            rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);

            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision other) {
        jumpCount = 0;
    }
}
