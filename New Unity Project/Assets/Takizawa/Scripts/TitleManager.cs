using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TouchManager.Instance.m_TouchFlag)
        {
            if (TouchManager.Instance.m_TouchPos.x < Screen.width / 2)
            {
                MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.SETTING);
            }
            else
            {
                MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.MAIN);
            }
        }
    }
}
