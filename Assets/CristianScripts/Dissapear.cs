using UnityEngine;

public class Dissapear : MonoBehaviour
{
    float dissapearTimer=10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dissapearTimer -= Time.deltaTime;
        if (dissapearTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
