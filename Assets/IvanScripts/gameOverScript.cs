using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class gameOverScript : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    public bool gameHasEnded = false;

    [SerializeField] private Canvas gameOverScreen;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }



    public void Setup()
    {        
        if (gameHasEnded == false)
        {
            Time.timeScale = 0f;
            gameOverScreen.enabled = true;
            Debug.Log("game over");
            gameHasEnded = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("hi");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene.buildIndex, LoadSceneMode.Additive);
        GameObject playerObject = playerHealth.gameObject;
        playerHealth.health = playerHealth.maxHealth;
        SceneManager.MoveGameObjectToScene(playerObject, currentScene);

        SceneManager.UnloadSceneAsync(currentScene);
        gameOverScreen.enabled = false;
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
