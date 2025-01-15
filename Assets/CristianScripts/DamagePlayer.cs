using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int Damage;
    public bool Directional;
    public int Force;
    public bool destroyOnHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player"&&other.gameObject.GetComponent<PlayerHealth>().invincibilityTime<=0)
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= Damage;
            other.gameObject.GetComponent<PlayerHealth>().invincibilityTime = 1;
            if (Directional == true)
            {
                other.gameObject.GetComponent<PlayerMove>().damageVelocity += transform.forward * Force;
            }
            else
            {
                other.gameObject.GetComponent<PlayerMove>().damageVelocity += other.transform.forward * -Force;
            }
            if (destroyOnHit == true)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
