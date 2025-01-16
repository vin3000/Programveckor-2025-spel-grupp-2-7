using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerVincent : MonoBehaviour
{
    [SerializeField]
    private float interactRange;

    [SerializeField]
    private GameObject settingsUI;

    List<IItem> items;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        items = new List<IItem>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange));
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange))
            {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.TryGetComponent<IItem>(out IItem item))
                {
                    Debug.Log("gaaa");
                    BoxCollider pickupCollider = hit.transform.gameObject.GetComponent<BoxCollider>();
                    pickupCollider.enabled = false;
                    item.PickUp();
                    Debug.Log(items.Count);
                    for (global::System.Int32 i = 0; i < items.Count; i++)
                    {
                        Debug.Log(i);
                        if (items[i] != null) continue;
                        items.Insert(i, item);
                        //fix this
                    }
                }
            }
        }
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            settingsUI.SetActive(true);
        }

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * hit.distance, Color.yellow); //ta bort senare
        }
    }



    private void FixedUpdate()
    {
    }
}
