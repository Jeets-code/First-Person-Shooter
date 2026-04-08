using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100; // The players starting health
    public int currentHealth; // The players current health
    public AudioClip deathClip; // The audio clip to play when the player dies.
    public Text healthText; // Reference to the health text UI

    PlayerShooting playerShooting; // Reference to the player shooting script
    AudioSource playerAudio; // Reference to the player audio

    bool isDead; // Whether or not the player is dead
    bool damaged; // True when the player gets damaged


    // Start is called before the first frame update
    void Start()
    {
        //Set up the reference of playerShooting and player audio
        playerShooting = GetComponentInChildren<PlayerShooting>();
        playerAudio = GetComponent<AudioSource>();

        // Set current health equal to starting health
        currentHealth = startingHealth;

        // Set up the health text UI
        healthText.text = "Health:" + startingHealth + "/" + startingHealth;


    }

    // Update is called once per frame
    void Update()
    {
        // Update the health text UI
        healthText.text = "Health:" + currentHealth + "/" + startingHealth;
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the amount of damage taken
        currentHealth -= amount;

        // Update the health text UI
        healthText.text = "Health:" + currentHealth + "/" + startingHealth;

        // Play the hurt sound effect.
        playerAudio.Play();


        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }


    }
    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        playerShooting.DisableEffects();

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerShooting.enabled = false;

        // Change the health text to "You're dead :("
        healthText.text = "You're dead :(";
    }
}
