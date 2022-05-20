using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    // Start is called before the first frame update
    private void Awake()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
