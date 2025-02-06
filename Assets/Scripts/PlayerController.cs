using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody mRigidbody;
    private bool mCanJump = false;


    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mCanJump) { 
            mRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            mCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            mCanJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle") {
            SceneManager.LoadScene("Game");
        }
    }
}
