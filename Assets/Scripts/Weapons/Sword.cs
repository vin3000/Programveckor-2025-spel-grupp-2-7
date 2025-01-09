using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public SphereCollider collider; //�ndra till en stor sphere framf�r spelaren
    void Start()
    {
        collider = this.GetComponent<SphereCollider>();
        collider.enabled = false;
    }

    public IEnumerator Attack()
    {
        Debug.Log("attacked");
        collider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        collider.enabled = false;
    }

    private void OnTriggerEnter(Collider hit)
    {
        Destroy(hit.gameObject);
    }
}
