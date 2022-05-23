using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMgr : MonoBehaviour
{
    HeadBobController headBobScript;
    CharacterControllerMovement moveScript;

    public static AudioMgr inst;

    [HideInInspector]
    public string sceneName;

    [Header("Number Variables")]
    [SerializeField] [Range(5000,20000)] float muffledFrequency = 19000;
    [SerializeField] [Range(5000, 20000)] float normalFrequency = 5000;

    [Header("Dreamcore Background Sounds")]
    public AudioSource DreamcoreBackgroundSource;
    public AudioClip[] birdSounds;

    [Header("House Background Sounds")]
    public AudioSource HouseBackgroundSource;
    public AudioClip cricketsSound;
    public AudioHighPassFilter highPass;

    [SerializeField] AudioSource FootstepSounds;
    public AudioClip windSounds;
    public AudioClip[] grassSounds;

    [SerializeField] AudioSource DiegeticSound;


    // Start is called before the first frame update
    private void Awake()
    {
        headBobScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HeadBobController>();
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMovement>();
        highPass = GetComponentInChildren<AudioHighPassFilter>();
        inst = this;
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Dreamcore Hills")
        {
            DreamcoreBackgroundSource.volume = .2f;
            //DreamcoreBackgroundSource.Play();

            PlayWind();
        }
        else if (sceneName == "House")
        {
            HouseBackgroundSource.volume = .05f;

            PlayCrickets();
        }
    }
    // Update is called once per frame
    void Update()
    {
        /* If background sfx not playing, play */
        /* NOTE** we should add a list of sounds to queue to avoid repetitive sounds */
        if (sceneName == "House")
        {
            
        }
        else if (sceneName == "Dreamcore Hills")
        {

        }
        
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

    void PlayCrickets()
    {
        HouseBackgroundSource.volume = 0.3f;
        HouseBackgroundSource.loop = true;
        highPass.cutoffFrequency = muffledFrequency;
        HouseBackgroundSource.PlayOneShot(cricketsSound);
    }

    public void HouseHighPassOff()
    {
        highPass.cutoffFrequency = normalFrequency;
    }

    public void HouseHighPassOn()
    {
        highPass.cutoffFrequency = muffledFrequency;
    }
}

