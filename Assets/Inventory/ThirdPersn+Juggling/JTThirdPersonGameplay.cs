using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTThirdPersonGameplay : MonoBehaviour
{
    public JTHand RightHand;
    public KeyCode usebutton = KeyCode.E;
    //Add all other buttons

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(usebutton))
        {
            if (RightHand.GetItem())
            {
                Debug.Log($"Use {RightHand.GetItem().name}");
            }
        }
    }
}
