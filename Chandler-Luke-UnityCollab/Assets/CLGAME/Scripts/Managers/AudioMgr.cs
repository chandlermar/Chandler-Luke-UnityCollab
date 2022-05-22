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

    [SerializeField] AudioSource FootstepSounds;
    public AudioClip windSounds;
    public AudioClip[] grassSounds;

    [SerializeField] AudioSource DiegeticSound;


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

        PlayWind();
    }
    // Update is called once per frame
    void Update()
    {
        /* If background sfx not playing, play */
        /* NOTE** we should add a list of sounds to queue to avoid repetitive sounds */
        /*if (!DreamcoreBackgroundSource.isPlaying)
        {
            DreamcoreBackgroundSource.PlayOneShot(birdSounds[Random.Range(0, birdSounds.Length)]);
        }*/
    }

    public void PlayFootstep()
    {
        if (moveScript.controller.isGrounded)
        {
            FootstepSounds.volume = Random.Range(0.1f, 0.3f);
            FootstepSounds.pitch = Random.Range(0.5f, 1f);
            FootstepSounds.PlayOneShot(grassSounds[Random.Range(0, grassSounds.Length)]);
        }
    }

    void PlayWind()
    {
        DiegeticSound.clip = windSounds;
        DiegeticSound.volume = 0.1f;
        DiegeticSound.loop = true;
        DiegeticSound.Play();
    }
}

