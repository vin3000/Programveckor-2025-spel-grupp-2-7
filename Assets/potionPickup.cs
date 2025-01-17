using UnityEngine;

public class potionPickup : MonoBehaviour, IItem
{
    public bool pickedUp { get; set; }
    public PlayerHealth playerHealth;
    public void PickUp()
    {
        pickedUp = true;
        this.transform.SetParent(Camera.main.transform);
        this.transform.localPosition = new Vector3(-0.438f, -0.349f, 0.77f);
        this.transform.localRotation = new Quaternion(1.46460854e-06f, -1, 1.50674259e-06f, 5.85615544e-06f);
        playerHealth.nrOfPotions += 1;
        //playerHealth.potionEquiped = true;
    }
    public void Drop()
    {

    }
}
