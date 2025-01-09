using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public SphereCollider collider; //ändra till en stor sphere framför spelaren
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
