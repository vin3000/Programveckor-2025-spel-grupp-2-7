using System.Collections;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;
    LookAtPlayer lookAtPlayer;
    [SerializeField] private AudioClip goblinSoundEffect;
    private bool playing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookAtPlayer = GetComponent<LookAtPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPlayer.looking == true)
        {
            float oldvelocityY = rb.linearVelocity.y;
            rb.linearVelocity = transform.forward * Speed;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, oldvelocityY, rb.linearVelocity.z);
            StartCoroutine(goblinAmbience());
        }
        

    }
    IEnumerator goblinAmbience()
    {
        if (playing)
        {
            StopCoroutine(goblinAmbience());
        }
        else
        {
            playing = true;
            SoundFXManager.instance.PlaySoundFXClip(goblinSoundEffect, this.transform, 0.75f, 110f);
            yield return new WaitForSeconds(Random.Range(2, 10));
            playing = false;
        }

    }
}
