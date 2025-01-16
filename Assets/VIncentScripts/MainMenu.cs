using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuUI;

    [SerializeField]
    private GameObject settingsUI;

    [SerializeField]
    private GameObject ingameSettingsUI;

    private bool paused = false;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void CloseSettingsMenuInGame()
    {
        settingsUI.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed");
            if (!paused)
            {
                PauseGame();
            }
            /*if (paused)
            {
                UnpauseGame();
            }
            */
        }
    }

    public void PauseGame()
    {
        paused = true;
        ingameSettingsUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        if (paused)
        {
            paused = false;
            ingameSettingsUI.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
}
