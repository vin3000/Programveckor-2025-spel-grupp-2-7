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
    [SerializeField] private Image fadeInImage;
    [SerializeField] private GameObject controlsGuideUI;
    [SerializeField] private GameObject crosshair;
    public static bool playingCutscene;
    private string tempText;
    private float scrollSpeed = 0.1f; //lower = faster
    private bool isScrolling = false;
    private bool isFading = false;
    private bool skipped = false;

    AudioSource voice;
    private Rigidbody rb;

    void Start()
    {
        cutsceneAnimation = GetComponent<Animation>();
        voice = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        playingCutscene = true;
        Player.SetActive(false);
        tempText = cutsceneText.text;
        cutsceneText.text = "";
        rb.isKinematic = true;
        StartCoroutine(fadeIn());

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (!cutsceneTextBox.activeSelf) return;
            skipped = true;
            StopCoroutine(fadeIn());
            StopCoroutine(scrollText());
            EnablePlayer();
            TextDisable();
            CloseControlsGuide();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            scrollSpeed = 0.03f;
        } else
        {
            scrollSpeed = 0.1f;
        }
        

    }
    public void TextEnable()
    {
        while (isFading) return;
        cutsceneTextBox.SetActive(true);
        StartCoroutine(scrollText());
        voice.Play();
    }

    public void ShowControlsGuide()
    {
        //FIX SO MOUSE NOT LOCKED!!!!
        Cursor.lockState = CursorLockMode.None;
        controlsGuideUI.SetActive(true);
    }

    public void CloseControlsGuide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controlsGuideUI.SetActive(false);
        EnablePlayer();
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
        if(skipped == false) ShowControlsGuide();
        rb.isKinematic = false;
        yield return new WaitForSeconds(5f);
        TextDisable();

    }

    IEnumerator fadeIn()
    {
        fadeInImage.gameObject.SetActive(true);
        isFading = true;

        while(fadeInImage.color.a > 0)
        {
            if (skipped)
            {
                Debug.Log("skip!");
                fadeInImage.color = new Color(0, 0, 0, 0);
                yield return null;
            }
            fadeInImage.color -= new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(scrollSpeed);
        }
        isFading = false;
        rb.isKinematic = false;
        cutsceneAnimation.Play();
    }

    private void EnablePlayer()
    {
        crosshair.SetActive(true);
        playingCutscene = false;
        Player.SetActive(true);
        cutsceneCamera.gameObject.SetActive(false);
    }

    public void TextDisable()
    {
        cutsceneTextBox.SetActive(false);
        rb.isKinematic = false;
        voice.Stop();
    }

}
