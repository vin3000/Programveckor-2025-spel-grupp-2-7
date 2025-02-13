using System;
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

    [SerializeField]
    private AudioClip arrowSoundEffect;

    private BowArrow currentArrow;

    private bool isReloading;

    public bool pickedUp { get; set; } = false;

    public void Reload()
    {
        //Ladda om pilb�gen
        if (pickedUp == false || isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    public void PickUp()
    {
        pickedUp = true;
        Reload();
        this.transform.SetParent(Camera.main.transform);
        this.transform.SetLocalPositionAndRotation(new Vector3(1.12f, -1.20000005f, -0.0700000003f), new Quaternion(1.46460854e-06f, -1, 1.50674259e-06f, 5.85615544e-06f));
    }

    public void Drop()
    {
        pickedUp = false;
        //rb.isKinematic = false;
        this.transform.SetParent(null);
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
        //SKjut iv�g en pil
        if (!pickedUp || Time.timeScale == 0f) return;
        //Om pilb�gen inte plockats upp s� kan den inte skjutas
        if (isReloading || currentArrow == null) return;
        //var force = arrowSpawnPoint.TransformDirection(Vector3.back * firePower);
        var force = (Camera.main.transform.forward * firePower);
        currentArrow.fired = true;
        SoundFXManager.instance.PlaySoundFXClip(arrowSoundEffect, currentArrow.transform, 1f, 500);
        currentArrow.Fly(force);
        currentArrow = null;
        Reload();
    }

    public bool isReady()
    {
        return (!isReloading && currentArrow != null);
    }
    private void OnEnable()
    {
        if (currentArrow == null&&pickedUp==true)
        {
            isReloading = true;
            StartCoroutine(ReloadAfterTime());
        }
    }
}
