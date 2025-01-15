using UnityEngine;

public class Cutscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    Animation cutsceneAnimation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cutsceneAnimation.isPlaying == true)
        {
            Player.GetComponent<PlayerMove>().enabled = false;
            

        }
    }
}
