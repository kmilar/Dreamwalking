using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Array to hold footstep sound clips
    public float minTimeBetweenFootsteps = 0.3f; // Minimum time between footstep sounds
    public float maxTimeBetweenFootsteps = 0.6f; // Maximum time between footstep sounds

    private AudioSource audioSource; 
    public bool isWalking = false; 
    private float timeSinceLastFootstep; 

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    private void Update()
    {
        // Check if the player is walking
        if (isWalking)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {
                // Play a random footstep sound from the array
                AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.PlayOneShot(footstepSound);

                timeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
            }
        }
    }

    // Call this method when the player starts walking
    public void StartWalking()
    {
        isWalking = true;
    }

    // Call this method when the player stops walking
    public void StopWalking()
    {
        isWalking = false;
    }
}
