using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : Singleton<TitleManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("UserData");
        }


        if (TouchManager.Instance.m_TouchFlag)
        {
            ChangeSceneFromTitle();
        }
    }

    public void ChangeSceneFromTitle()
    {
        if (!PlayerPrefs.HasKey("UserData"))
        {
            MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.REGISTER);
        }
        else
        {
            MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.MAIN);
        }
    }
}
