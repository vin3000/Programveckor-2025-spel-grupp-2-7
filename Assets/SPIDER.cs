using UnityEngine;

public class SPIDER : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform Player;
    public GameObject spiderShot;
    Vector3 lookRotation;
    float shootTimer=1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookRotation = (Player.position - transform.position).normalized;
        lookRotation.y = 0;
        transform.rotation = Quaternion.LookRotation(lookRotation);
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            shootTimer = 2;
            GameObject shot = Instantiate(spiderShot, transform.position+transform.forward*2, Quaternion.identity);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * 5,ForceMode.Impulse);
        }
        
    }
}
