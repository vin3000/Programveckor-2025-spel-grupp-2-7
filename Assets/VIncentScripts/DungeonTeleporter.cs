using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonTeleporter : MonoBehaviour
{
    public string m_Scene;

    public GameObject playerObject;

    void Update()
    {
    }

    IEnumerator LoadYourAsyncScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(playerObject, SceneManager.GetSceneByName(m_Scene));

        SceneManager.UnloadSceneAsync(currentScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerObject)
        {
            CharacterController playerController = other.gameObject.GetComponent<CharacterController>();
            PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();
            playerController.enabled = false;
            playerMove.enabled = false;
            StartCoroutine(LoadYourAsyncScene());
        }
            
    }
}