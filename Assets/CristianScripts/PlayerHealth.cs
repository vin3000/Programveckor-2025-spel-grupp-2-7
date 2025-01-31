using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health;
    public int maxHealth;
    public float invincibilityTime;

    public bool potionEquiped;
    public int nrOfPotions;

    public float shakeTimer;

    public gameOverScript gameOverScript;

    [SerializeField] private AudioClip potionSoundEffect;
    [SerializeField] private TextMeshProUGUI healthText;
    void Start()
    {
        health = maxHealth;
        potionEquiped = false;
        nrOfPotions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            Camera.main.transform.localPosition = new Vector3(0, 0.64f, -0.3f) +Random.insideUnitSphere * 0.5f;
            shakeTimer -= Time.fixedDeltaTime;
        }
        else
        {
            Camera.main.transform.localPosition = new Vector3(0, 0.64f, -0.3f);
        }
        healthText.text = "Health: " + health;
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
