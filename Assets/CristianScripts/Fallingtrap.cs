using UnityEngine;

public class Fallingtrap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    Vector3 originalPosition;
    [SerializeField]
    float fallTimer;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        originalPosition = transform.parent.position;
        fallTimer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (fallTimer <= 0)
        {
            rb.transform.position = originalPosition;
            rb.isKinematic = true;
        }
        else
        {
            fallTimer -= Time.deltaTime; 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 3 && rb.isKinematic == true && fallTimer <= 0) //så länge någonting annat än marken är under fällan så faller den
        {
            Fall();
        }
    }
    void Fall()
    { 
        rb.isKinematic = false;
        rb.AddForce(Vector3.down * 200, ForceMode.Impulse);
        fallTimer = 3;
    }
}
