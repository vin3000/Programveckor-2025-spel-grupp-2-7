using UnityEngine;

public class Torch : MonoBehaviour, IItem
{
    public bool pickedUp { get; set; } = false;

    public void PickUp()
    {
        pickedUp = true;
        this.transform.SetParent(Camera.main.transform);
        this.transform.localPosition = new Vector3(-1.26149714f, -0.303999931f, 1.1410079f);
        this.transform.localRotation = new Quaternion(0, 0, 0, 1);
    }
}
