﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : Singleton<MainManager>
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenConfig()
    {
        MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.CONFIG);
    }
}
