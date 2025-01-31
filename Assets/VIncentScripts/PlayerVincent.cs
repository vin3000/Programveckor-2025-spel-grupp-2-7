using System.Collections.Generic;
using UnityEngine;

public class PlayerVincent : MonoBehaviour
{
    [SerializeField]
    private float interactRange;

    private PlayerHealth playerHealth;

    public int DungeonExit;

    List<IItem> items = new List<IItem>();

    int selectedItem;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }



    private void Start()
    {
        TryGetComponent<PlayerHealth>(out playerHealth);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange))
            {
                
                
                //Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.TryGetComponent<IItem>(out IItem item))
                {
                    print(item.gameObject.name);
                    //Skicka ut en raycast och försöker ta upp det den träffar.
                    if (!(item.gameObject.GetComponent<potionPickup>() != null&&playerHealth.nrOfPotions>0))
                    {
                        Collider pickupCollider = hit.transform.gameObject.GetComponent<Collider>();
                        if(pickupCollider == null)
                        {
                            pickupCollider = hit.transform.parent.gameObject.GetComponent<Collider>();
                        }
                        pickupCollider.enabled = false;
                        item.PickUp();
                        //Debug.Log(items.Count);
                        if (item.gameObject.GetComponent<Torch>() == null)
                        {
                            items.Add(item);
                        }
                        
                    }
                    else
                    {
                        Destroy(item.gameObject);
                        playerHealth.nrOfPotions++;
                    }
                    
                    
                   
                    
                    /*for (global::System.Int32 i = 0; i < items.Count; i++)
                    {
                        Debug.Log(i);
                        if (items[i] != null) continue;
                        items.Insert(i, item);
                        //fix this
                    }
                    */
                }
                
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = 1;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedItem = 2;

        }
        for (int i = 0; i < items.ToArray().Length; i++)
        {
            if (i == selectedItem)
            {
                items[i].gameObject.SetActive(true);
                if (items[i].gameObject.GetComponent<potionPickup>() != null)
                {
                    playerHealth.potionEquiped = true;
;                }
                else
                {
                    playerHealth.potionEquiped = false;
                }
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
            if (items[i].gameObject.GetComponent<potionPickup>() != null)
            {
                if (playerHealth.nrOfPotions == 0)
                {
                    Destroy(items[i].gameObject);
                    items.Remove(items[i]);
                }
            }
        }
        if(selectedItem> items.ToArray().Length-1)
        {
            playerHealth.potionEquiped = false;
        }


        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(items[1]);
            for (global::System.Int32 i = -1; i < items.Count; i++)
            {
                if (items[i] != null) continue;
                items.RemoveAt(i);
                items[i].Drop();
                break;
                //fix this
            }
        }
        */

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange))
        {
            //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * hit.distance, Color.yellow); //ta bort senare
        }
    }
}
