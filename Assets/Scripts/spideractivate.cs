using System.Collections;
using UnityEngine;

public class spideractivate : MonoBehaviour
{
    public SPIDER spider;
    [SerializeField] private AudioSource bossMusic;
    void Start()
    {
        spider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            spider.gameObject.SetActive(true);
            bossMusic.Play();
        }
    }
}
