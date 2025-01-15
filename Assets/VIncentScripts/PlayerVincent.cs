using UnityEngine;

public class PlayerVincent : MonoBehaviour
{
    [SerializeField]
    private float interactRange;


    void Start()
    {
    }


    void Update()
    {

    }



    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange))
            {
                if (hit.transform.parent.TryGetComponent<IItem>(out IItem item))
                {
                    BoxCollider ItemCollider = hit.transform.gameObject.GetComponent<BoxCollider>();
                    ItemCollider.enabled = false;
                    item.PickUp();
                }
                else return;
            }
        }
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * hit.distance, Color.yellow); //ta bort senare
        }
    }
}
