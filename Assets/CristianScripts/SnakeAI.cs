using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    
    public float speed;
    LookAtPlayer lookAtPlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookAtPlayer = GetComponentInChildren<LookAtPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPlayer.looking == true)
        {
            float oldvelocityY = rb.linearVelocity.y;
            rb.linearVelocity = transform.up * speed;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, oldvelocityY, rb.linearVelocity.z);
        }
    }
}
