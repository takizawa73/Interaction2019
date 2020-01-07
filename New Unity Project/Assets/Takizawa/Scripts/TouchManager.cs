using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : Singleton<TouchManager>
{
    public bool m_TouchFlag;
    public Vector2 m_TouchPos;
    public TouchPhase m_TouchPhase;

    public Vector2 m_MousePos;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        m_TouchFlag = false;
        m_TouchPos = Vector2.zero;
        m_TouchPhase = TouchPhase.Canceled;
    }

    public void Update()
    {
        m_TouchFlag = false;

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_TouchFlag = true;
                m_TouchPhase = TouchPhase.Began;
            }

            if (Input.GetMouseButtonUp(0))
            {
                m_TouchFlag = true;
                m_TouchPhase = TouchPhase.Ended;
            }

            if (Input.GetMouseButton(0))
            {
                m_TouchFlag = true;
                m_TouchPhase = TouchPhase.Moved;
            }

            if (m_TouchFlag)
            {
                m_TouchPos = Input.mousePosition;
            }

            m_MousePos = Input.mousePosition;
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                m_TouchPos = touch.position;
                m_TouchPhase = touch.phase;
                m_TouchFlag = true;
            }
        }
    }
}
