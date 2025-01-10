using UnityEngine;

public class CArrow : MonoBehaviour
{
    float life;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life = 10;
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
            Destroy(gameObject);
        
    }
}
