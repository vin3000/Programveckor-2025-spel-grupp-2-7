using UnityEngine;

public class spideractivate : MonoBehaviour
{
    public SPIDER spider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        print("lo");
        if (collision.tag == "Player")
        {
            spider.gameObject.SetActive(true);
            Destroy(gameObject);
            
        }
    }
}
