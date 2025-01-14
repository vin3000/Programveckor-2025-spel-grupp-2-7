using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour, IItem
{
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private BowArrow arrowPrefab;

    [SerializeField]
    private Transform arrowSpawnPoint;

    private BowArrow currentArrow;

    private bool isReloading;

    public bool pickedUp { get; set; } = false;

    public void Reload()
    {
        //Ladda om pilbågen
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    public void PickUp()
    {
        pickedUp = true;
        this.transform.SetParent(Camera.main.transform);
        this.transform.localPosition = new Vector3(1.12f, -1.20000005f, -0.0700000003f);
        this.transform.localRotation = new Quaternion(1.46460854e-06f, -1, 1.50674259e-06f, 5.85615544e-06f);
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
        if (!pickedUp) return;
        //Skjut en pil
        if (isReloading || currentArrow == null) return;
        //var force = arrowSpawnPoint.TransformDirection(Vector3.back * firePower);
        var force = (Camera.main.transform.forward * firePower);
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
