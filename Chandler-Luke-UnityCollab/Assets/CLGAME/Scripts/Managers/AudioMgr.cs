using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr inst;

    [Header("Dreamcore Background Sounds")]
    public AudioSource DreamcoreBackgroundSource;
    public AudioClip summerBirdsAudio;

    // Start is called before the first frame update
    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        DreamcoreBackgroundSource.volume = .2f;
        DreamcoreBackgroundSource.clip = summerBirdsAudio;
        DreamcoreBackgroundSource.Play();
        Debug.Log("Birds chirping");
    }
    // Update is called once per frame
    void Update()
    {
        /* If background sfx not playing, play */
        /* NOTE** we should add a list of sounds to queue to avoid repetitive sounds */
        if (!DreamcoreBackgroundSource.isPlaying)
        {
            Debug.Log("Birds stopped chirping");
            DreamcoreBackgroundSource.Play();
        }
    }

    void PlayAmbientBirds()
    {

    }
}
