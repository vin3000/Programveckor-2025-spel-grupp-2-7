using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject settingsMenu;

    [SerializeField]
    private GameObject confirmationPrompt;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                if(settingsMenu.activeSelf)
                {
                    CloseSettingsMenu();
                    return;
                }
                if(confirmationPrompt.activeSelf)
                {
                    CloseConfirmationPrompt();
                    return;
                }
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;
    }

    public void OpenSettingsMenu()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(true);
        
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void OpenConfirmationPrompt()
    {
        foreach (Transform button  in pauseMenuUI.transform)
        {
            if (button.gameObject == confirmationPrompt) continue;
            button.gameObject.SetActive(false);
        }
        confirmationPrompt.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void CloseConfirmationPrompt()
    {
        confirmationPrompt.SetActive(false);
        foreach (Transform button in pauseMenuUI.transform)
        {
            if (button.gameObject == confirmationPrompt) continue;
            button.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
