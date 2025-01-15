using UnityEngine;

public class Torch : MonoBehaviour, IItem
{
    public bool pickedUp { get; set; } = false;

    //private Rigidbody rb;

    private void Start()
    {
        //rb = this.GetComponent<Rigidbody>();
    }



    public void PickUp()
    {
        //rb.isKinematic = true;
        pickedUp = true;
        this.transform.SetParent(Camera.main.transform);
        this.transform.SetLocalPositionAndRotation(new Vector3(-1.26149714f, -0.303999931f, 1.1410079f), new Quaternion(0, 0, 0, 1));
    }

    public void Drop()
    {
        pickedUp = false;
        //rb.isKinematic = false;
        this.transform.SetParent(null);

    }
}
