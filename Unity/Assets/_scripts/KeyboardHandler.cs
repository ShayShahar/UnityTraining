using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{
    public static bool IsPaused;

    private bool m_isPaused = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_isPaused = !m_isPaused;
        }

    }

    private void OnGUI()
    {
        if (m_isPaused)
        {
            Debug.Log("ESC");
            GUI.Label(new Rect(10, 10, 100, 100), "Pause");
        }
    }
}
