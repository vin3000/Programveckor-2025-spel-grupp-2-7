using UnityEngine;

public class Interfaces
{
    
}

public interface IItem
{
    public bool pickedUp { get; set; }
    void PickUp();
}

public interface IDamageable
{
    void Damage(float damage);
}