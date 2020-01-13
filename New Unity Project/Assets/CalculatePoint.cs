using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CalculatePoint : MonoBehaviour
{
    int ITERATION_LIMIT = 1000;

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
    double u1;
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

    double u2;
    double c2a;
    double sig;

    double c2am;
    double sigo, coso, delo, sigd, x, lamda, C, L;

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

        u1 = Math.Atan((1 - f) * Math.Tan(lat1));

        su1 = Math.Sin(u1);
        cu1 = Math.Cos(u1);
        tu1 = Math.Tan(u1);

        s1 = Math.Atan2(tu1, cb);
        sa = cu1 * sb;
        c2a = 1 - sa * sa;
        u2 = c2a * (a * a - b * b) / (b * b);
        A = 1 + u2 / 16384 * (4096 + u2 * (-768 + u2 * (320 - 175 * u2)));
        B = u2 / 1024 * (256 + u2 * (-128 + u2 * (74 - 47 * u2)));

        sig = s / (b * A);

        for (int i = 0; i < ITERATION_LIMIT; i++)
        {
            c2am = Math.Cos(2 * s1 + sig);
            sigo = Math.Sin(sig);
            coso = Math.Cos(sig);
            delo = B * sigo * (c2am + B / 4 * (coso * (-1 + 2 * c2am * c2am) - B / 6 * c2am * (-3 + 4 * sigo * sigo) * (-3 + 4 * c2am * c2am)));
            sigd = sig;
            sig = s / (b * A) + delo;

            if (Math.Abs(sig - sigd) <= 1.00e-12)
            {
                break;
            }
        }
        

        x = su1 * sigo - cu1 * coso * cb;
        lat2 = Math.Atan2(su1 * coso + cu1 * sigo * cb, (1 - f) * Math.Sqrt(sa * sa + x * x));
        lamda = Math.Atan2(sigo * sb, cu1 * coso - su1 * sigo * cb);
        C = f / 16 * c2a * (4 + f * (4 - 3 * c2a));
        L = lamda - (1 - C) * f * sa * (sig + C * sigo * (c2am + C * coso * (-1 + 2 * c2am * c2am)));

        lat2 = lat2 * 180 / Math.PI;
        lon2 = (L + lon1) * 180 / Math.PI;

        //lat2 = (L + lo) * 180 / Math.PI;

        /*tu1 = (1 - f) * Math.Tan(lat1);
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
       }*/

        //Console.WriteLine("{0} {1}", lat2, lon2);
        //Debug.Log(Bearing);
        Debug.Log("StartPoint:" + Latitude + ", " + Longitude);
        Debug.Log("Heading&Distance:" + Bearing + ", " + s);
        Debug.Log("CalPoint:" + lat2 + ", " + lon2);
    }
}
