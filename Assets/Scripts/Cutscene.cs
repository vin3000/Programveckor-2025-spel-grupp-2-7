using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject Player;
    Animation cutsceneAnimation;
    [SerializeField] private Camera cutsceneCamera;
    [SerializeField] private GameObject cutsceneTextBox;
    [SerializeField] private TextMeshProUGUI cutsceneText;
    private string tempText;
    private float scrollSpeed = 0.05f;
    private bool isScrolling = false;
    AudioSource voice;
    Rigidbody rb;

    void Start()
    {
        Player.SetActive(false);
        cutsceneAnimation = GetComponent<Animation>();
        voice = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        tempText = cutsceneText.text;
        cutsceneText.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            EnablePlayer();
            TextDisable();
        }
        
        

    }
    public void TextEnable()
    {

        cutsceneTextBox.SetActive(true);
        StartCoroutine(scrollText());
        voice.Play();
    }

    IEnumerator scrollText()
    {
        if (isScrolling) StopCoroutine(scrollText());
        isScrolling = true;
        for (int i = 0; i < tempText.Length; i++)
        {
            cutsceneText.text += tempText.Substring(i, 1);
            yield return new WaitForSeconds(scrollSpeed);
            isScrolling = false;
        }
        EnablePlayer();
        yield return new WaitForSeconds(5f);
        TextDisable();

    }

    private void EnablePlayer()
    {
        Player.SetActive(true);
        rb.isKinematic = false;
        cutsceneCamera.gameObject.SetActive(false);
    }

    public void TextDisable()
    {
        cutsceneTextBox.SetActive(false);
        voice.Stop();
    }

}
