using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Cutscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    Animation cutsceneAnimation;
    public Camera cutsceneCamera;
    public TextMeshProUGUI text;
    AudioSource voice;
    Rigidbody rb;

    float cutsceneTime=0;
    void Start()
    {
        cutsceneAnimation = GetComponent<Animation>();
        voice = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cutsceneTime += Time.deltaTime;
        if (cutsceneAnimation.isPlaying == false && cutsceneTime > 11f)
        {
            Player.SetActive(true);
            text.enabled = false;
            rb.isKinematic = false;

        }
        else
        {
            cutsceneCamera.gameObject.SetActive(true);
            rb.isKinematic = true;
            
        }
        
        

    }
    public void TextEnable()
    {
        text.enabled = true;
        voice.Play();
    }
    public void TextDisable()
    {
        
    }

}
