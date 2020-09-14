using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoQuitGame : MonoBehaviour
{
    public KeyCode exitKey = KeyCode.Escape;
    void Update()
    {
        if (Input.GetKeyDown(exitKey))
        {
            Application.Quit();
        }
    }
}
