using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationUpdate : MonoBehaviour
{
    public float IntervalSeconds = 1.0f;
    public LocationServiceStatus Status;
    public LocationInfo Location;
    public double latitude;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            this.Status = Input.location.status;
            if (Input.location.isEnabledByUser)
            {
                switch (this.Status)
                {
                    case LocationServiceStatus.Stopped:
                        Input.location.Start();
                        break;
                    case LocationServiceStatus.Running:
                        this.Location = Input.location.lastData;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Debug.Log("location is disabled by user");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
