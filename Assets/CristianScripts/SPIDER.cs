using Unity.VisualScripting;
using UnityEngine;

public class SPIDER : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform Player;
    
    public GameObject spiderShot;
    public GameObject webPrefab;
    public GameObject shockWave;
    Rigidbody rb;

    Vector3 lookRotation;

    float shootTimer = 1;
    float shockTimer;
    float webTimer;

    public float jumpForce;
    
    
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lookRotation = (Player.position - transform.position).normalized;
        lookRotation.y = 0;
        transform.rotation = Quaternion.LookRotation(lookRotation);
        
        shootTimer -= Time.deltaTime;
        shockTimer -= Time.deltaTime;
        webTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            shootTimer = 1.5f;
            GameObject shot = Instantiate(spiderShot, transform.position+transform.forward*2, Quaternion.identity);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * 100,ForceMode.Impulse);
        }
        if (shockTimer <= 0)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            shockTimer = 4;
        }
        if (webTimer <= 0)
        {
            Instantiate(webPrefab, Player.transform.position += Vector3.up * 10,Quaternion.identity);
            webTimer = 6;
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Instantiate(shockWave, transform.position, Quaternion.identity);
        }
    }
}
