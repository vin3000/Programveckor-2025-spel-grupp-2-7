using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //Variables
    private BoxCollider collider;
    private float hitBoxDuration = 1f;
    private bool isAttacking = false;

    void Start()
    {
        collider = this.GetComponent<BoxCollider>();
        collider.enabled = false;
    }

    public IEnumerator Attack()
    {
        //Svinga sv�rdet och g�r s� att allt det tr�ffar tar skada (just nu f�rst�r det d� vi inte har ett health system).
        if(!isAttacking)
        {
            collider.enabled = true;
            isAttacking = true;
            yield return new WaitForSeconds(hitBoxDuration);
            collider.enabled = false;
            isAttacking = false;
        }
        else
        {
            StopCoroutine(Attack());
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        Destroy(hit.gameObject);
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
