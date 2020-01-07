using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    public enum E_Scene
    {
        TITLE   = 0,
        SETTING = 1,
        MAIN    = 2,
    }

    public E_Scene m_Scene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        m_Scene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(E_Scene scene)
    {
        if (scene == E_Scene.SETTING)
        {
            SceneManager.LoadScene("FirstSetting");
        }

        if (scene == E_Scene.MAIN)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
