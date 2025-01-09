using UnityEngine;

public class PlayerVincent : MonoBehaviour
{
    //Variables
    public Sword sword;
    
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("raaaa");
            StartCoroutine(sword.Attack());
        }
    }
}
