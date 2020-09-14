using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoRebootGame : MonoBehaviour
{
    public KeyCode rebootKey = KeyCode.F5;
    private int StartSceneIndex;
    private void Start()
    {
        StartSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        if (Input.GetKeyDown(rebootKey))
        {
            SceneManager.LoadScene(StartSceneIndex);
        }
    }
}
