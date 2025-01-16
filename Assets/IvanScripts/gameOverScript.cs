using UnityEngine;

public class gameOverScript : MonoBehaviour
{
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void Setup()
    {
        gameObject.SetActive(true);

    }
}
