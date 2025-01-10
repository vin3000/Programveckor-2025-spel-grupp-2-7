using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidbody;

    private bool didHit;


    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (didHit) return;
        didHit = true;

        if (collider.gameObject.TryGetComponent<IDamageable>(out IDamageable enemy))
        {
            enemy.Damage(200);
        }

        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        transform.SetParent(collider.transform);
    }
}
