using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    float shootTimer;
    public GameObject arrowPrefab;
    public float Force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = 2;
        }
    }
    void Shoot()
    {
        GameObject Arrow = Instantiate(arrowPrefab, transform.position+transform.forward*2, Quaternion.identity);
        Arrow.transform.rotation = transform.rotation;
        Arrow.GetComponent<Rigidbody>().AddForce(transform.forward*Force,ForceMode.Impulse);
    }
}
