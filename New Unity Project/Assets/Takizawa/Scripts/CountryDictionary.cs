using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class CountryDictionary : MonoBehaviour
{
    TextAsset csvFile;
    List<string[]> csvDatas = new List<string[]>();
    int Datanum = 0;

    public GameObject m_Content;
    public GameObject m_TextPrefab;

    bool m_Flag = true;

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("CountryList_txt") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
            Datanum++;
        }

        //var gm = GameManager.Instance;
        //int i = 1;
        //while (i < Datanum)
        //{
        //    string name = "?????";
        //    for (int j = 0; j < gm.user.sentMessages.Count; j++)
        //    {
        //        if (csvDatas[i][0] == gm.user.sentMessages[j].destination)
        //        {
        //            name = csvDatas[i][0];
        //        }
        //    }

        //    var textObject = Instantiate(m_TextPrefab);
        //    textObject.transform.SetParent(m_Content.transform);
        //    textObject.GetComponent<Text>().text = name;

        //    i++;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Flag)
        {
            var gm = GameManager.Instance;
            int i = 1;
            while (i < Datanum)
            {
                string name = "?????";
                for (int j = 0; j < gm.user.sentMessages.Count; j++)
                {
                    if (csvDatas[i][0] == gm.user.sentMessages[j].destination)
                    {
                        name = csvDatas[i][0];
                    }
                }

                var textObject = Instantiate(m_TextPrefab);
                textObject.transform.SetParent(m_Content.transform);
                textObject.GetComponent<Text>().text = name;

                i++;
            }
            m_Flag = false;
        }
    }

    public void ReturnMain()
    {
        MySceneManager.Instance.ChangeScene(MySceneManager.E_Scene.MAIN);
    }
}
