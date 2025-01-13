using UnityEngine;

public class PlayerVincent : MonoBehaviour
{
    Camera camera;
    LayerMask itemLayerMask;
    void Start()
    {
        camera = Camera.main;
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Input.GetKey(KeyCode.E))
        {
            Debug.Log("hi");
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(camera.transform.position, camera.transform.forward * hit.distance, Color.yellow);
                Debug.Log("Hit " + hit.transform.gameObject.name);
                if(hit.transform.gameObject.CompareTag("Item"))
                {
                    GameObject bow = hit.transform.parent.gameObject;
                    foreach(CapsuleCollider bowModelCollider in bow.GetComponentsInChildren<CapsuleCollider>())
                    {
                        bowModelCollider.enabled = false;
                    }
                    bow.transform.SetParent(camera.transform);
                    bow.transform.localPosition = new Vector3(0.875f, -1.40361762f, -0.151999995f);
                    bow.transform.localRotation = new Quaternion(1.49011594e-08f, 1, -1.29229947e-13f, 4.54747351e-13f);
                }
            }
        }
    }
}
