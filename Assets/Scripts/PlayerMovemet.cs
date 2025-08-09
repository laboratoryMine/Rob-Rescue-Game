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
    public float moveThreshold = 0.1f;
    // public string sceneName;

    bool isMoving;
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
        if (forward != Vector3.zero) {
             isMoving = true;
        }

         isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > moveThreshold;

        float speed = new Vector3(forward.x,0,forward.z).magnitude / Time.deltaTime;

        if (speed < 0.01f) speed = 0f;

        anim.SetFloat("Walking",speed);


        SFXManager.Instance.playerWalk.Play();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            walk = 10f;
        }
        else
        {
            walk = 5f;
        }
        // Debug.Log(speed);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            // to always stick to the ground


        }

        if (isMoving)
        {
            if (!SFXManager.Instance.playerWalk.isPlaying)
                SFXManager.Instance.playerWalk.Play();
        }
        else
        {
            if (SFXManager.Instance.playerWalk.isPlaying)
                SFXManager.Instance.playerWalk.Stop();
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
