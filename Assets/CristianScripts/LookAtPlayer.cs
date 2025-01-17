
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    Vector3 lookRotation;
    Vector3 lookPosition;
    Transform Player;
    
    void Start()
    {
        if (FindAnyObjectByType<PlayerMove>() != null)
        {
            FindAnyObjectByType<PlayerMove>().TryGetComponent<Transform>(out Player);
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            lookPosition = Player.position;
            lookPosition.y = transform.position.y;
            lookRotation = (lookPosition - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(lookRotation);

            if (transform.parent != null)
            {
                transform.parent.transform.eulerAngles = new Vector3(90, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        
        
        
        
            
        
    }
}
