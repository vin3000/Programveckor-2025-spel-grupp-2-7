using System;
using System.Collections;
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

    [SerializeField]
    private BoxCollider tipCollider;

    public void Fly(Vector3 force)
    {
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (fired)
        {
            if (didHit) return;
            didHit = true;

            if (collider.gameObject.TryGetComponent<IDamageable>(out IDamageable enemy))
            {
                enemy.Damage(damage);

            }
            StopArrow(collider);



        }
        else return;

    }

    private void StopArrow(Collider objectHit)
    {
        //Får pilen att stanna och fastna i det den träffar
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        bodyCollider.enabled = false;
        tipCollider.enabled = false;
        StartCoroutine(StartDestroyCountdown());
    }

    IEnumerator StartDestroyCountdown()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    private void Update()
    {
    }
}
