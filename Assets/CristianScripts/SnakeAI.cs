using System.Collections;
using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    
    public float speed;
    LookAtPlayer lookAtPlayer;
    [SerializeField] private AudioClip snakeSoundEffect;
    private bool playing = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookAtPlayer = GetComponentInChildren<LookAtPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPlayer.looking == true)
        {
            float oldvelocityY = rb.linearVelocity.y;
            rb.linearVelocity = transform.up * speed;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, oldvelocityY, rb.linearVelocity.z);
            StartCoroutine(snakeAmbience());
        }
    }

    IEnumerator snakeAmbience()
    {
        if (playing)
        {
            StopCoroutine(snakeAmbience());
        }
        else
        {
            playing = true;
            SoundFXManager.instance.PlaySoundFXClip(snakeSoundEffect, this.transform, 0.25f, 125f);
            yield return new WaitForSeconds(Random.Range(1, 10));
            playing = false;
        }
    }
}
