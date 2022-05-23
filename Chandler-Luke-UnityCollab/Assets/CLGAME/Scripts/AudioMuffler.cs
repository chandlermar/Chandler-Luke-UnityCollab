using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMuffler : MonoBehaviour
{

    AudioMgr audioManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        audioManagerScript = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            audioManagerScript.HouseHighPassOff();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioManagerScript.HouseHighPassOn();
        }
    }
}
