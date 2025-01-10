using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private Arrow arrowPrefab;

    [SerializeField]
    private Transform arrowSpawnPoint;

    private Arrow currentArrow;

    private bool isReloading;

    public void Reload()
    {
        //Ladda om pilb�gen
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentArrow = Instantiate(arrowPrefab, arrowSpawnPoint);
        currentArrow.transform.localPosition = Vector3.zero; //fixa s� att pilen inte spawnar ovanf�r huvudet p� spelaren.
        isReloading = false;
    }

    public void Fire(float firePower)
    {
        //Skjut en pil
        if (isReloading || currentArrow == null) return;
        var force = arrowSpawnPoint.TransformDirection(Vector3.back * firePower);
        currentArrow.Fly(force);
        currentArrow = null;
        Reload();
    }

    public bool isReady()
    {
        return (!isReloading && currentArrow != null);
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
        }
    }
}
