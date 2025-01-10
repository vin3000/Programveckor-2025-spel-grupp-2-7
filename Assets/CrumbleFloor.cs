using UnityEngine;

public class CrumbleFloor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float breakTimer = 1;
    bool breakFloor = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (breakFloor == true)
        {
            breakTimer -= Time.deltaTime;

        }
        if (breakTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        {
            
            if (other.gameObject.layer != 3)
            {
                
                breakTimer = 1;
                breakFloor = true;
                
            }
        }
    }
}

    

