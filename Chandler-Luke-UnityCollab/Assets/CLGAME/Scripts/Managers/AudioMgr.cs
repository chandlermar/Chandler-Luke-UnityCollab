using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    HeadBobController headBobScript;
    CharacterControllerMovement moveScript;

    public static AudioMgr inst;

    [Header("Dreamcore Background Sounds")]
    public AudioSource DreamcoreBackgroundSource;
    public AudioClip[] birdSounds;

    [SerializeField] AudioSource DiegeticSound;
    public AudioClip[] grassSounds;


    // Start is called before the first frame update
    private void Awake()
    {
        headBobScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HeadBobController>();
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMovement>();
        inst = this;
    }

    private void Start()
    {
        DreamcoreBackgroundSource.volume = .2f;
        //DreamcoreBackgroundSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (moveScript.controller.isGrounded)
        {

        }

        /* If background sfx not playing, play */
        /* NOTE** we should add a list of sounds to queue to avoid repetitive sounds */
        /*if (!DreamcoreBackgroundSource.isPlaying)
        {
            DreamcoreBackgroundSource.PlayOneShot(birdSounds[Random.Range(0, birdSounds.Length)]);
        }*/
    }

    public void PlayFootstep()
    {
        DiegeticSound.volume = Random.Range(0.1f,0.3f);
        DiegeticSound.pitch = Random.Range(0.5f, 1f);
        DiegeticSound.PlayOneShot(grassSounds[Random.Range(0, grassSounds.Length)]);
    }
}

