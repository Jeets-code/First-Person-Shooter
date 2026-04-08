using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20; // The damage inflicted by each bullet.
    public float fireRate = 0.15f; // The rate at which the gun is able to be fired
    public float weaponRange = 50f; // The distance the gun can fire
    public int startingAmmo = 10; // The starting ammo of your weapon
    private int currentAmmo; // The current ammo your weapon has


    float timer; // A timer to determine when to fire.
    Ray shootRay = new Ray(); // The ray shot from the gun
    RaycastHit shootHit; // A raycast hit to get information about what was hit.
    int shootableMask; // A layermask so the Raycast can hit things on the shootable layer
    int reloadableMask; // A layermask so the Raycast can hit things on the reloadable layer
    int healingMask; // A layerMask so the Raycast can hit things on the switching layer

    ParticleSystem gunParticles;// Reference to the particle system
    LineRenderer gunLine; // Reference to the line renderer
    AudioSource gunAudio; // Reference to the audio
    Light gunLight; // Reference to the light component
    public Light faceLight;

    float effectsDisplayTime = 0.2f; // The proportion of the timeBetweenBullets that the effects will display for.

    public Text ammoText; // Reference to the ammo text UI

    PlayerHealth playerHealth; // Just so I can test the health text, whenever I shoot one of the boxes remove one hp



    void Awake()
    {
        // Create a layer mask for the Shootable, Reloadable and Switching layer 
        shootableMask = LayerMask.GetMask("Shootable");
        reloadableMask = LayerMask.GetMask("Reloadable");
        healingMask = LayerMask.GetMask("Healing");

        // Set up the references for the particle system, line renderer, audio, and light component
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        faceLight = GetComponentInChildren<Light>();

        // Set the current ammo to the starting ammo
        currentAmmo = startingAmmo;

        // Set up the ammo text UI
        ammoText.text = "Ammo: " + startingAmmo + "/" + startingAmmo;

        // Set up the references for the PlayerHealth Script
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= fireRate && Time.timeScale != 0)
        {
            // Shoot the gun
            Shoot();
        }
        if (timer >= fireRate * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
        // Update the ammo text UI
        ammoText.text = "Ammo: " + currentAmmo + "/" + startingAmmo;
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;

    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            // Reset the timer
            timer = 0.0f;

            // Lose one round of ammunition
            currentAmmo--;

            //Play the gunshot audio clip
            gunAudio.Play();

            //Enable the lights
            gunLight.enabled = true;
            faceLight.enabled = true;

            // Stop the particles from playing if they were, then start the particles.
            gunParticles.Stop();
            gunParticles.Play();

            // Enable the line renderer and set it's first position to be the end of the gun.
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if (Physics.Raycast(shootRay, out shootHit, weaponRange, shootableMask))
            {
                // Try and find an EnemyHealth script on the gameobject hit.
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition(1, shootHit.point);

                // If the EnemyHealth component exists...
                if (enemyHealth != null)
                {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }
            }
            // If the raycast didn't hit anything on the shootable layer...

            else if (Physics.Raycast(shootRay, out shootHit, weaponRange, reloadableMask))
            {
                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition(1, shootHit.point);

                //Reload the gun
                Reload();
            }

            else if (Physics.Raycast(shootRay, out shootHit, weaponRange, healingMask))
            {
                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition(1, shootHit.point);

                // Switch the gun
                Heal();
            }
            else
            {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * weaponRange);
            }

        }
        
    }

    public void Reload() {
        // Set the ammo back to the max ammount of ammo
        currentAmmo = startingAmmo;

        // Reset the ammo text UI
        ammoText.text = "Ammo: " + startingAmmo + "/" + startingAmmo;

        playerHealth.currentHealth -= 5;
        if (playerHealth.currentHealth < 0)
        {
            playerHealth.currentHealth = 0;
        }
    }

    public void Heal()
    {
        //Heal the  player
        playerHealth.currentHealth += 5;
        // If the players health goes above 100 reset it to 100
        if (playerHealth.currentHealth > 100)
        {
            playerHealth.currentHealth = 100;
        }
    }


}

