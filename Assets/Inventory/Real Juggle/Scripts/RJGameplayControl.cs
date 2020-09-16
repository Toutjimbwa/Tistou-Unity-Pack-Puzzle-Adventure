using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJGameplayControl : MonoBehaviour
{
    public RJThirdPersonGameplay thirdPersonGameplay;
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl thirdPersonUserControl;
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPersonCharacter;
    public GameObject thirdPersonCamera;
    public GameObject pickUpAbility;

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
        pickUpAbility.SetActive(_thirdPerson);

        //Inventory
        inventoryGO.SetActive(!_thirdPerson);
        if (!_thirdPerson)
        {
            inventoryGO.GetComponent<RJInventory>().Open();
        }
        else
        {
            inventoryGO.GetComponent<RJInventory>().Close();
        }

        _thirdPerson = !_thirdPerson;
    }
}
