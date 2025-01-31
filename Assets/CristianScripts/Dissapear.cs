using System.Collections;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(destroyAfterTime());
    }

    // Update is called once per frame
    IEnumerator destroyAfterTime() 
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
    
}
