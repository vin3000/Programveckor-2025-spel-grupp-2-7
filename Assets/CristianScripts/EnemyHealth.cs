using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
