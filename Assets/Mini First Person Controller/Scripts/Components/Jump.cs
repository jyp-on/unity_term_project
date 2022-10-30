using UnityEngine;

public class Jump : MonoBehaviour
{
    public AudioSource audioSource;
    new Rigidbody rigidbody;
    public float jumpStrength = 4;
    public bool isJumped; //점프했는지 여부


    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (!isJumped))
        {
            isJumped = true;
            rigidbody.AddForce(Vector3.up * 150 * jumpStrength);
            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Boat")
        {
            isJumped = false;
        }
    }
}
