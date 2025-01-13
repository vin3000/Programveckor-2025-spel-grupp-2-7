using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //Variables
    private BoxCollider swordCollider;
    private float hitBoxDuration = 1f;
    private bool isAttacking = false;

    void Start()
    {
        swordCollider = this.GetComponent<BoxCollider>();
        swordCollider.enabled = false;
    }

    public IEnumerator Attack()
    {
        //Svinga sv�rdet och g�r s� att allt det tr�ffar tar skada (just nu f�rst�r det d� vi inte har ett health system).
        if(!isAttacking)
        {
            swordCollider.enabled = true;
            isAttacking = true;
            yield return new WaitForSeconds(hitBoxDuration);
            swordCollider.enabled = false;
            isAttacking = false;
        }
        else
        {
            StopCoroutine(Attack());
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.TryGetComponent<IDamageable>(out IDamageable enemy))
        {
            enemy.Damage(25);
        }
    }

    private void Update()
    {
        //Anv�nd sv�rd
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }
}
