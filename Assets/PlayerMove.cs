using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //variabler som håller koll på om vi är på marken 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
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

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
