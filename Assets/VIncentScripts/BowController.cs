using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField]
    private Bow bow;

    [SerializeField]
    private float maxFirePower;

    [SerializeField]
    private float minFirePower;

    [SerializeField]
    private float firePowerSpeed;

    private float firePower;

    private bool fire;

    void Start()
    {
        bow?.Reload();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            fire = true;
        } 

       if(fire && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
        }

       if(fire && Input.GetMouseButtonUp(0))
        {
            firePower = Mathf.Clamp(firePower, minFirePower, maxFirePower);
            bow?.Fire(firePower); //frågetecknet gör att metoden bara kallas om bow har ett värde
            firePower = 0;
            fire = false;
        }
    }
}
