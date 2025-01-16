using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    

    [SerializeField]
    private Transform spawnPos;
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player)
        {
            player.transform.position = spawnPos.position;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Player found! " + "name: " + player.name);

        }
    }

}
