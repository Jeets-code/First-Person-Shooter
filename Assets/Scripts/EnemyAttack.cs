using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    public float weaponRange = 50f;

    Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;

    Ray shootRay = new Ray(); // The ray shot from the gun
    RaycastHit shootHit; // A raycast hit to get information about what was hit.
    int shootableMask; // A layermask so the Raycast can hit things on the shootable layer

    ParticleSystem gunParticles;// Reference to the particle system
    LineRenderer gunLine; // Reference to the line renderer

    Light gunLight; // Reference to the light component
    public Light faceLight;

    float effectsDisplayTime = 0.2f; // The proportion of the timeBetweenBullets that the effects will d


    // Start is called before the first frame update
    void Awake()
    {

        shootableMask = LayerMask.GetMask("Shootable");

        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
       
        gunLight = GetComponent<Light>();
        faceLight = GetComponentInChildren<Light>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            anim.SetTrigger("Attack");
            // ... the player is in range.
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            anim.SetTrigger("Standing");
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack();
        }

        if (timer >= timeBetweenAttacks * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();

        }
            // If the player has zero or less health...
            if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("Standing");
        }
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;

    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        gunLight.enabled = true;
        faceLight.enabled = true;


        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;


        if (Physics.Raycast(shootRay, out shootHit, weaponRange, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            PlayerHealth playerHealth = shootHit.collider.GetComponent<PlayerHealth>();

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition(1, shootHit.point);

            // If the player has health to lose...
            if (playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage(attackDamage);
            }
        }
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * weaponRange);
        }
    }

}
