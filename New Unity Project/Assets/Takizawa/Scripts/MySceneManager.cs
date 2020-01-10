using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    public enum E_Scene
    {
        TITLE   = 0,
        REGISTER= 1,
        MAIN    = 2,
        CONFIG  = 3,
        GAME    = 4,
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
        if (scene == E_Scene.REGISTER)
        {
            SceneManager.LoadScene("Register");
        }

        if (scene == E_Scene.MAIN)
        {
            SceneManager.LoadScene("Main");
        }

        if (scene == E_Scene.CONFIG)
        {
            SceneManager.LoadScene("Config");
        }

        if (scene == E_Scene.GAME)
        {
            SceneManager.LoadScene("TextInoutScene");
        }
    }
}
