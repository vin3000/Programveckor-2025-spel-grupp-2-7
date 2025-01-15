using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;

    //basic movement variables
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //crouching variables
    public float crouchSpeed=2f;
    public float standSpeed = 3f;
    public float standingHeight=1f;
    public float crouchHeight=0.5f;
    public float smoothTime=0.25f;
    public Vector3 offset;
    public Transform player;
    public bool crouching;

    //variabler som håller koll på om vi är på marken 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public Vector3 damageVelocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //skapar en sphere som kan kolla om vi rör marken
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //makes sure we move based on where the camera is facing and not the global coordinates
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouching = true;
        }
        else
        {
            crouching = false;
        }

        /*if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = !crouching;
        }*/

        if (crouching == false)
        {
            controller.height = controller.height - crouchSpeed * Time.deltaTime;
            if (controller.height <= standingHeight)
            {
                controller.height = crouchHeight;
            }
        }
        if (crouching == true)
        {
            controller.height = controller.height + crouchSpeed * Time.deltaTime;
               if (controller.height < standingHeight)
               {
                   player.position = player.position + offset * Time.deltaTime;
               }
            if (controller.height >= standingHeight)
            {
                controller.height = standingHeight;
            }
        }
    }
}
