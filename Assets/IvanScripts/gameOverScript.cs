using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class gameOverScript : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    public bool gameHasEnded = false;

    [SerializeField] private Canvas gameOverScreen;

    [SerializeField]
    private GameObject soundMixerManager, soundFXManager, musicManager;
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
            gameHasEnded = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Restart()
    {
        playerHealth.GetComponent<PlayerMove>().enabled=false;
        playerHealth.GetComponent<CharacterController>().enabled = false;
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene.buildIndex);
        //GameObject playerObject = playerHealth.gameObject;
        playerHealth.health = playerHealth.maxHealth;
        //SceneManager.MoveGameObjectToScene(playerObject, currentScene);

        //SceneManager.UnloadSceneAsync(currentScene);
        gameOverScreen.enabled = false;
        gameHasEnded = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMainMenu()
    {
        //Go back to main menu and move the player, pause menu and death handler from DontDestroyOnLoad so they don't get duplicated if you restart the game.
        GameObject player = playerHealth.gameObject;
        GameObject[] objectsToRemoveFromDNOD = {player, this.gameObject, soundFXManager, soundMixerManager, musicManager };
        foreach (GameObject gameObject in objectsToRemoveFromDNOD)
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }
}
