using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private BowArrow arrowPrefab;

    [SerializeField]
    private Transform arrowSpawnPoint;

    private BowArrow currentArrow;

    private bool isReloading;

    public void Reload()
    {
        //Ladda om pilbågen
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentArrow = Instantiate(arrowPrefab, arrowSpawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
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
