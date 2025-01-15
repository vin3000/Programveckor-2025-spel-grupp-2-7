using Unity.VisualScripting;
using UnityEngine;

public class SpiderShockWave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(Time.deltaTime*15, 0,Time.deltaTime*15);
        if (transform.localScale.x>45)
        {
            Destroy(gameObject);
        }
    }
}
