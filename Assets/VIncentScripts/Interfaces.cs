using UnityEngine;

public class Interfaces
{
    
}

public interface IItem
{
    public bool pickedUp { get; set; }
    void PickUp();

    void Drop();
}

public interface IInteractable
{
    void Interact();
}

public interface IDamageable
{
    void Damage(float damage);
}