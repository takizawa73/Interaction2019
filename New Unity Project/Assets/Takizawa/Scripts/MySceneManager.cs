using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using Random = UnityEngine.Random;

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

    TextAsset csvFile;
    List<string[]> csvDatas = new List<string[]>();
    int Datanum = 0;

    TextAsset MessageFile;
    List<string[]> MessageDatas = new List<string[]>();
    int DatanumM = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        m_Scene = 0;

        csvFile = Resources.Load("CountryList_txt") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        MessageFile = Resources.Load("MessageList") as TextAsset;
        StringReader readerM = new StringReader(MessageFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
            Datanum++;
        }

        while (readerM.Peek() != -1)
        {
            string line = readerM.ReadLine();
            MessageDatas.Add(line.Split(','));
            DatanumM++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(E_Scene scene)
    {
        var gm = GameManager.Instance;
        if (gm != null)
        {
            gm.SaveRecieveMessage(MessageDatas[Random.Range(0, DatanumM)][0], csvDatas[Random.Range(0, Datanum)][0], 
                Random.Range(0, 100).ToString(), DateTime.Now.ToString());
        }

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
