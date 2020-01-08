using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DecideSendCountry : MonoBehaviour
{
    TextAsset csvFile;
    List<string[]> csvDatas = new List<string[]>();
    List<double> Latitudelist = new List<double>();
    List<double> Longitudelist = new List<double>();

    GameObject Sumaho;
    CalculatePoint CalPscript;

    int Datanum = 0;
    double PointDistance = 0.0f;
    double MaxDistance = 40000000;
    double NearLat;
    double NearLon;
    int Nearnum;
    // Start is called before the first frame update
    void Start()
    {
        Sumaho = GameObject.Find("Sumaho");
        CalPscript = Sumaho.GetComponent<CalculatePoint>();

        csvFile = Resources.Load("CountryList_txt") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        //Debug.Log(csvFile.text);

        //Debug.Log("DecideStart");
        
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
            //Latitudelist.Add(double.Parse(csvDatas[i][1]));
           // Longitudelist.Add(double.Parse(csvDatas[i][2]));
            Datanum++;
            //Debug.Log(line);
            //Debug.Log(csvDatas[2][2]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecideSend()
    {
        //Debug.Log(csvDatas[2][2]);
        //Debug.Log(Latitudelist[1] + ", " + Longitudelist[1]);

        int i = 1;
        while (i < Datanum)
        {
            PointDistance = Math.Sqrt((CalPscript.lat2 - double.Parse(csvDatas[i][2])) * (CalPscript.lat2 - double.Parse(csvDatas[i][2])) 
                + (CalPscript.lon2 - double.Parse(csvDatas[i][3])) * (CalPscript.lon2 - double.Parse(csvDatas[i][3])));

            i++;

            if(PointDistance < MaxDistance)
            {
                MaxDistance = PointDistance;
                NearLat = double.Parse(csvDatas[i][2]);
                NearLon = double.Parse(csvDatas[i][3]);
                Nearnum = i;
                //Debug.Log(csvDatas[i][1]);
            }
        }
        Debug.Log(csvDatas[Nearnum][0] + ", " + NearLat + ", " + NearLon);
    }
}
