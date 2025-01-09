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
        //Svinga svärdet och gör så att allt det träffar tar skada (just nu förstör det då vi inte har ett health system).
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
        //Använd svärd
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }
}
