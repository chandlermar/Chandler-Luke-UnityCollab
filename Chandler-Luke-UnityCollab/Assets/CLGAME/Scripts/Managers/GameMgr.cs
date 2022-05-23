using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    [Header("Portal Setup")]
    public Camera cameraA;
    public Material cameraMatA;
    public Camera cameraB;
    public Material cameraMatB;


    // Start is called before the first frame update
    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        if (AudioMgr.inst.sceneName == "Dreamcore Hills")
        {
            if (cameraB.targetTexture != null)
            {
                cameraB.targetTexture.Release();
            }
            cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMatB.mainTexture = cameraB.targetTexture;

            if (cameraA.targetTexture != null)
            {
                cameraA.targetTexture.Release();
            }
            cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMatA.mainTexture = cameraA.targetTexture;
        }
        else if (AudioMgr.inst.sceneName == "House")
        {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
