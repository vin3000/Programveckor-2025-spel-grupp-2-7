using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour,IItem
{
    //Variables
    public bool pickedUp { get; set; }
    private BoxCollider swordCollider;
    private float hitBoxDuration = 1f;
    private bool isAttacking = false;
    Animation swordAnimation;
    public GameObject bloodEffect;
    [SerializeField] private AudioClip swordSoundEffect;
    [SerializeField] private BoxCollider itemCollider;

    void Start()
    {
        swordCollider = this.GetComponent<BoxCollider>();
        //swordCollider.enabled = false;
        swordAnimation = GetComponent<Animation>();
    }

    public IEnumerator Attack()
    {
        //Svinga svärdet och gör så att allt det träffar tar skada (just nu förstör det då vi inte har ett health system).
        if(!isAttacking)
        {
            SoundFXManager.instance.PlaySoundFXClip(swordSoundEffect, this.gameObject.transform, 30f, 500f);
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
        if(hit.gameObject.TryGetComponent<IDamageable>(out IDamageable enemy)&&pickedUp==true)
        {
            enemy.Damage(250);
            Instantiate(bloodEffect, hit.transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        //Använd svärd
        if (Input.GetMouseButtonDown(0)&&pickedUp)
        {
            if (Time.timeScale == 0f) return;
            swordAnimation.Play();
            //StartCoroutine(Attack());
        }
    }
    public void PickUp()
    {
        pickedUp = true;
        transform.SetParent(Camera.main.transform);
        transform.SetLocalPositionAndRotation(new Vector3(0.4f, -0.24f, 0.66f), new Quaternion(90, -68, 0, 0));
    }
    public void Drop()
    {

    }
}
