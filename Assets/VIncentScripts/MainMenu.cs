using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuUI;

    [SerializeField]
    private GameObject settingsUI;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(settingsUI.activeSelf)
            {
                CloseSettingsMenu();
            }
        }
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
}
