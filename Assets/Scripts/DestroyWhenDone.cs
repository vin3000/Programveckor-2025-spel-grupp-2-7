using UnityEngine;

public class DestroyWhenDone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInChildren<SpiderShockWave>().GetComponent<Transform>().localScale.x>100)
        {
            Destroy(gameObject);
        }
    }
}
