using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;

    //basic movement variables
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //crouching variables
    public float crouchSpeed = 6f;
    public float crouchYScale;
    public float standYScale;
    public float standSpeed = 12f; 
    public bool crouching;
    public bool canStand;

    //variabler som håller koll på om vi är på marken 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask spiderMask;

    Vector3 velocity;
    public Vector3 damageVelocity;
    bool isGrounded;


    private void Start()
    {
        standYScale = transform.localScale.y;
        canStand = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.up, Color.blue);
        new Ray(transform.position, transform.up);
        RaycastHit hit;
   
        if(Physics.Raycast(transform.position, transform.up, out hit, 4))
        {
            canStand = false;
        }
        else
        {
            canStand = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)&&isGrounded)
        {
            crouching = true;
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            speed = crouchSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl)&&isGrounded && canStand)
        {
            crouching = false;
            transform.localScale = new Vector3(transform.localScale.x, standYScale, transform.localScale.z);
            speed = 12;
        }


        //skapar en sphere som kan kolla om vi rör marken
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask) && !Physics.CheckSphere(groundCheck.position, groundDistance, spiderMask,QueryTriggerInteraction.Collide) ;


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //makes sure we move based on where the camera is facing and not the global coordinates
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && !crouching)
        {
            //physics equation to get how high we jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (damageVelocity.magnitude > 0)
        {
            
            damageVelocity *= 0.91f;
            if (damageVelocity.magnitude < 0.01f)
            {
                damageVelocity = Vector3.zero;
            }
            
        }
        
       

        velocity.y += gravity * Time.deltaTime;

        controller.Move((velocity+damageVelocity) * Time.deltaTime);

       

    }
}
