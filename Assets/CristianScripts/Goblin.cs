using UnityEngine;

public class Goblin : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;
    LookAtPlayer lookAtPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookAtPlayer = GetComponent<LookAtPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPlayer.looking == true)
        {
            float oldvelocityY = rb.linearVelocity.y;
            rb.linearVelocity = transform.forward * Speed;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, oldvelocityY, rb.linearVelocity.z);
        }
        

    }
}
