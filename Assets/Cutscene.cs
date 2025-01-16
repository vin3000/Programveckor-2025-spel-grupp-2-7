using TMPro;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    Animation cutsceneAnimation;
    public Camera cutsceneCamera;
    public TextMeshProUGUI text;
    AudioSource voice;
    void Start()
    {
        cutsceneAnimation = GetComponent<Animation>();
        voice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cutsceneAnimation.isPlaying == false && voice.isPlaying == false)
        {
            Player.SetActive(true);
            text.enabled = false;

        }
        else
        {
            cutsceneCamera.gameObject.SetActive(true);
            
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
