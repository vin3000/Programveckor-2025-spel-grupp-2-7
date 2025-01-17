using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health;
    public int maxHealth;
    public float invincibilityTime;

    public bool potionEquiped;
    public int nrOfPotions;

    public gameOverScript gameOverScript;

    [SerializeField] private AudioClip potionSoundEffect;
    void Start()
    {
        health = maxHealth;
        potionEquiped = false;
        nrOfPotions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        invincibilityTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && potionEquiped == true)
        {
            if (nrOfPotions <= 0) return;
            health += 5;
            SoundFXManager.instance.PlaySoundFXClip(potionSoundEffect, this.gameObject.transform, 10f, 500);
            nrOfPotions -= 1;

        }
        if (health <= 0 && gameOverScript.gameHasEnded == false)
        {
            gameOverScript.Setup();
        }
    }

    
}
