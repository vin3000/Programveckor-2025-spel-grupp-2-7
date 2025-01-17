using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    

    [SerializeField]
    private Transform spawnPos;

    [SerializeField]
    private int DungeonExit;
    private void Start()
    {
        PlayerVincent playerFound = GameObject.FindWithTag("Player").GetComponent<PlayerVincent>();
        if (playerFound)
        {
            if (playerFound.DungeonExit == DungeonExit)
            {
                //playerFound.DungeonExit = 0;
                playerFound.gameObject.transform.position = spawnPos.position;
                playerFound.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                CharacterController playerController = playerFound.gameObject.GetComponent<CharacterController>();
                PlayerMove playerMove = playerFound.gameObject.GetComponent<PlayerMove>();
                playerController.enabled = true;
                playerMove.enabled = true;
            }
            else return;
        }
    }

}
