using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    [Header("Portal Setup")]
    public Camera cameraB;
    public Material cameraMatB;

    // Start is called before the first frame update
    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
