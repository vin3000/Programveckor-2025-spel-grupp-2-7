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
                if (Cutscene.playingCutscene) return;
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
        //Sätter timescale till noll, låser musen och öppnar paus menyn
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
        confirmationPrompt.SetActive(false);
        GameObject player = GameObject.FindWithTag("Player");
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
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
}
