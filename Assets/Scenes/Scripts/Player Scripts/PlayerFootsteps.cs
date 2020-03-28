using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource footstepSound;

    [SerializeField]
    private AudioClip[] footstepClip;

    private CharacterController characterController;

    [HideInInspector]
    public float volumeMin, volumeMax;

    private float accumulatedDistance;

    [HideInInspector]
    public float stepDistance;


    // Start is called before the first frame update
    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();

        characterController = GetComponentInParent<CharacterController>(); //grabs component from player object
    }

    // Update is called once per frame
    void Update()
    {
        CheckFootsteps();
    }

    void CheckFootsteps()
    {
        if (!characterController.isGrounded)//are you in the air?
        {
            return;
        }

        if(characterController.velocity.sqrMagnitude > 0) // how far you can move, sprint, crouch, etc until the footstep sound plays
        {
            accumulatedDistance += Time.deltaTime;

            if(accumulatedDistance > stepDistance)
            {
                footstepSound.volume = Random.Range(volumeMin, volumeMax);
                footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                footstepSound.Play();

                accumulatedDistance = 0f;
            }
        }
        else
        {
            accumulatedDistance = 0f;
        }


    }


}//end class
