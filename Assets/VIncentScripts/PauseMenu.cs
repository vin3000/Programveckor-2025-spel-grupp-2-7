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

    [SerializeField]
    private GameObject deathScreenHandler;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject soundMixerManager, soundFXManager, musicManager;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
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
        //S�tter timescale till noll, l�ser musen och �ppnar paus menyn
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
        GameObject[] objectsToRemoveFromDNOD = {player, this.gameObject, deathScreenHandler, soundFXManager, soundMixerManager, musicManager};
        //Go back to main menu and move the player, pause menu and death handler from DontDestroyOnLoad so they don't get duplicated if you restart the game.
        confirmationPrompt.SetActive(false);
        foreach (GameObject gameObject in objectsToRemoveFromDNOD)
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
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
