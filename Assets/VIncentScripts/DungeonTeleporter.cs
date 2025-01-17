using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonTeleporter : MonoBehaviour
{
    [SerializeField] private string m_Scene;

    [SerializeField] private PlayerVincent player;

    [SerializeField] private int DungeonExit;

    private void Start()
    {
        PlayerVincent playerFound = GameObject.FindWithTag("Player").GetComponent<PlayerVincent>();
        if(SceneManager.GetActiveScene().name != "MainScene")
        {
            player = playerFound;
        }
    }

    /*  IEnumerator LoadYourAsyncScene()
      {
          Scene currentScene = SceneManager.GetActiveScene();

          AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

          while (!asyncLoad.isDone)
          {
              yield return null;
          }

          SceneManager.UnloadSceneAsync(currentScene);
      }
  */ //ska testa dontdestroyonload istället

    private void LoadDungeonScene() 
    {
        SceneManager.LoadScene(m_Scene);
    }
    private void OnTriggerEnter(Collider other)     
    {
        if(other.gameObject == player.gameObject)
        {
            CharacterController playerController = other.gameObject.GetComponent<CharacterController>();
            PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();
            playerController.enabled = false;
            playerMove.enabled = false;
            //StartCoroutine(LoadYourAsyncScene());
            player.DungeonExit = DungeonExit;
            LoadDungeonScene();
        } 
            
    }
}