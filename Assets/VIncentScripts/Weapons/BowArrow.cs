using System;
using UnityEngine;

public class BowArrow : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rb;

    [NonSerialized]
    public bool fired = false;

    private bool didHit;

    [SerializeField]
    private BoxCollider bodyCollider;

    public void Fly(Vector3 force)
    {
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(fired)
        {
            if (didHit) return;
            didHit = true;

            if (collider.gameObject.TryGetComponent<IDamageable>(out IDamageable enemy))
            {
                enemy.Damage(damage);
            }
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            bodyCollider.enabled = false;
            transform.SetParent(collider.transform);
        }
        else return;

    }

    private void Update()
    {
        if(this.transform.parent == null)
        {
            fired = true;
        }
    }
}
