using UnityEngine;

public class PlayerMovemet : MonoBehaviour
{



    Animator anim;


    public float walk = 5f;

    public float rotate = 50f;

    CharacterController cc;

    public float jumpHeight = 5f;

    Vector3 velocity;
    float gravity = -9.81f;
    bool isGrounded;

    public string sceneName;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }



    private void Update()
    {


        isGrounded = cc.isGrounded;

        float leftRight = Input.GetAxis("Horizontal");
        float frontBack = Input.GetAxis("Vertical");

        transform.Rotate(0, leftRight * rotate * Time.deltaTime, 0);
        
        

        Vector3 forward = transform.forward * frontBack * walk * Time.deltaTime;

        cc.Move(forward);

        float speed = new Vector3(forward.x,0,forward.z).magnitude / Time.deltaTime;

        if (speed < 0.01f) speed = 0f;
        anim.SetFloat("Walking",speed);
        
       // Debug.Log(speed);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            // to always stick to the ground
        }
        Jumpping();
    }

    void Jumpping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //we apply the velocity to the y
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        //  to always apply the gravity
        velocity.y += gravity * Time.deltaTime;

        // add the y move to the cc
        cc.Move(velocity * Time.deltaTime);
    }
}
