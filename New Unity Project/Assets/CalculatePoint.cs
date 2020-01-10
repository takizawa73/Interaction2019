using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CalculatePoint : MonoBehaviour
{
    double Latitude;  //開始緯度
    double Longitude; //開始経度
    double Bearing;  //方位

    double lat1;　//開始緯度をラジアンに
    double lon1; //開始経度をラジアンに
    double brg;　//方位をラジアンに
    double s; //目的地までの距離

    static double a = 6378137.0; //半長軸
    static double b = 6378137.0 * (1 - 1 / 298.257223563); //半短軸

    static double f = 1 / 298.257223563; //地球の平坦化のための数値
    double sb;
    double cb;
    double tu1;
    double cu1;
    double su1;
    double s2;
    double sa;
    double csa;
    double us;
    double A;
    double B;
    double s1;
    double s1p;
    double cs1m;
    double ss1;
    double cs1;

    double t;
    public double lat2;
    double l2;
    double c;
    double l;
    double d;
    double finalBrg;
    double backBrg;
    public double lon2;

    GameObject Sumaho;
    SumAcceleration SumAccscript;
           
// Start is called before the first frame update
void Start()
    {
        Sumaho = GameObject.Find("Sumaho");
        SumAccscript = Sumaho.GetComponent<SumAcceleration>();
    }

    // Update is called once per frame
    public void CalPoint()
    {
        //Latitude = SumAccscript.Latitude;
        //Longitude = SumAccscript.Longitude;
        //Bearing = SumAccscript.Heading;
        Latitude = 24.288472;
        Longitude = 153.9707894;
        Bearing = 276.8697566783211;
        s = 3143772;

        lat1 = Latitude * (Math.PI / 180.0);
        lon1 = Longitude * (Math.PI / 180.0);

        brg = Bearing * (Math.PI / 180.0);
        //s = SumAccscript.Distance;
        sb = Math.Sin(brg);
        cb = Math.Cos(brg);
        tu1 = (1 - f) * Math.Tan(lat1);
        cu1 = 1 / Math.Sqrt((1 + tu1 * tu1));
        su1 = tu1 * cu1;
        s2 = Math.Atan2(tu1, cb);
        sa = cu1 * sb;
        csa = 1 - sa * sa;
        us = csa * (a * a - b * b) / (b * b);
        A = 1 + us / 16384 * (4096 + us * (-768 + us * (320 - 175 * us)));
        B = us / 1024 * (256 + us * (-128 + us * (74 - 47 * us)));
        s1 = s / (b * A);
        s1p = 2 * Math.PI;

        while (Math.Abs(s1 - s1p) > 1e-12)
        {
            cs1m = Math.Cos(2 * s2 + s1);
            ss1 = Math.Sin(s1);
            cs1 = Math.Cos(s1);
            double ds1 = B * ss1 * (cs1m + B / 4 * (cs1 * (-1 + 2 * cs1m * cs1m) - B / 6 * cs1m * (-3 + 4 * ss1 * ss1) * (-3 + 4 * cs1m * cs1m)));
            s1p = s1;
            s1 = s / (b * A) + ds1;
        }

        t = su1 * ss1 - cu1 * cs1 * cb;
        lat2 = Math.Atan2(su1 * cs1 + cu1 * ss1 * cb, (1 - f) * Math.Sqrt(sa * sa + t * t));
        l2 = Math.Atan2(ss1 * sb, cu1 * cs1 - su1 * ss1 * cb);
        c = f / 16 * csa * (4 + f * (4 - 3 * csa));
        l = l2 - (1 - c) * f * sa * (s1 + c * ss1 * (cs1m + c * cs1 * (-1 + 2 * cs1m * cs1m)));
        d = Math.Atan2(sa, -t);
        finalBrg = d + 2 * Math.PI;
        backBrg = d + Math.PI;
        lon2 = lon1 + l;

        lat2 = lat2 * 180 / Math.PI;
        lon2 = lon2 * 180 / Math.PI;
        finalBrg = finalBrg * 180 / Math.PI;
        backBrg = backBrg * 180 / Math.PI;

        if (lon2 < -180)
        {
            lon2 = lon2 + 360;
        }
        if (lon2 > 180)
        {
            lon2 = lon2 - 360;
        }

        if (finalBrg < 0)
        {
            finalBrg = finalBrg + 360;
        }
        if (finalBrg > 360)
        {
            finalBrg = finalBrg - 360;
        }

        //Console.WriteLine("{0} {1}", lat2, lon2);
        //Debug.Log(Bearing);
        //Debug.Log(lat2 + ", " + lon2);
    }
}
