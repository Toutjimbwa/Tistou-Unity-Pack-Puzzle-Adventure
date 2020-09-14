using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTGameplayControl : MonoBehaviour
{
    public JTThirdPersonGameplay thirdPersonGameplay;
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl thirdPersonUserControl;
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPersonCharacter;
    public GameObject thirdPersonCamera;
    public GameObject inventoryCamera;
    public GameObject inventoryGO;
    private bool _thirdPerson;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchGameplay();
        }
    }
    
    void SwitchGameplay()
    {
        //Third person
        thirdPersonUserControl.enabled = _thirdPerson;
        thirdPersonCharacter.enabled = _thirdPerson;
        thirdPersonGameplay.enabled = _thirdPerson;
        thirdPersonCamera.SetActive(_thirdPerson);

        //Inventory
        inventoryGO.SetActive(!_thirdPerson);
        inventoryCamera.SetActive(!_thirdPerson);

        _thirdPerson = !_thirdPerson;
    }
}
