using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    

    [SerializeField]
    private Transform spawnPos;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player)
        {
            player.transform.position = spawnPos.position;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            CharacterController playerController = player.GetComponent<CharacterController>();
            PlayerMove playerMove = player.GetComponent<PlayerMove>();
            playerController.enabled = true;
            playerMove.enabled = true;

        }
    }

}
