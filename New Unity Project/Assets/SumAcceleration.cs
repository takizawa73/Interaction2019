using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumAcceleration : MonoBehaviour
{

    const int HISMAX = 10;      // 履歴の個数
    const float BORDER = 2.0f;  // しきい値
    public float SUMx = 0.0f;
    public float SUMy = 0.0f;
    public float SUMz = 0.0f;
    public float SUMall = 0.0f;
    public float Heading = 0.0f;
    public double Latitude;
    public double Longitude;
    public double Distance;
    Vector3 center;

    public LocationUpdate update;

    List<Vector3> history = new List<Vector3>(HISMAX);

    // Use this for initialization
    void Start()
    {
        center = transform.position;
        Input.compass.enabled = true; //コンパス有効化
        //Input.location.Start(); //位置情報有効化
        update = gameObject.GetComponent<LocationUpdate>();
    }

    // Update is called once per frame
    void Update()
    {

        float scale = 2f;
        Vector3 dir = Input.acceleration;
        Vector3 pos = new Vector3(
            center.x + dir.x * scale,
            center.y + dir.y * scale,
            center.z + dir.z * scale
        );
        this.transform.position = pos;

        if (history.Count >= HISMAX)
        {
            history.RemoveAt(0);
        }
        history.Add(pos);

        SUMx += dir.x;
        SUMy += dir.y;
        SUMz += dir.z;

        //DrawLines ();
    }

    private void OnGUI()
    {
        Vector3 dir = Input.acceleration;
        GUI.TextField(new Rect(10, 10, 100, 100), "X = " + dir.x.ToString());
        GUI.TextField(new Rect(10, 30, 100, 100), "Y = " + dir.y.ToString());
        GUI.TextField(new Rect(10, 50, 100, 100), "Z = " + dir.z.ToString());
        GUI.TextField(new Rect(10, 70, 100, 100), "SUMx = " + SUMx.ToString());
        GUI.TextField(new Rect(10, 90, 100, 100), "SUMy = " + SUMy.ToString());
        GUI.TextField(new Rect(10, 110, 100, 100), "SUMz = " + SUMz.ToString());
    }

    /*void DrawLines ()
    {
        for (int i = 1; i < history.Count; i++) {
            float distance = Vector3.Distance (history [i - 1], history [i]);
            Color col = (distance >= BORDER) ? Color.red : Color.green;
            Debug.DrawLine (history[i-1], history[i], col, 2.0f);
        }
    }*/

    public void DecideAddress()
    {
        SUMall = SUMx + SUMy + SUMz;  //加速度の和
        Distance = SUMall * (-10000);
        Debug.Log(SUMall);
        Debug.Log(Distance);
        //Debug.Log("Distance: " + Distance);
        Heading = Input.compass.trueHeading; //方位
        //Debug.Log("Heading: " + Heading);
        //Latitude = Input.location.lastData.latitude; //緯度取得
        //Latitude = update.Location.latitude;
        //Debug.Log(Latitude);
        //Longitude = Input.location.lastData.longitude; //経度取得
        //Longitude = update.Location.longitude;
        //Debug.Log(Longitude);
        //Distance = 1000000;
        Heading = 270;
        Latitude = 35.5557358;
        Longitude = 139.6537767;
    }
}

