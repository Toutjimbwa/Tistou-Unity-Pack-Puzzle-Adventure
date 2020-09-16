using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJThirdPersonGameplay : MonoBehaviour
{
    public RJHand RightHand;
    public RJHand LeftHand;
    //Add all other buttons

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (RightHand.GetItem())
            {
                Debug.Log($"Use {RightHand.GetItem().name}");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchItems();
        }
    }
    void SwitchItems()
    {
        var Litem = LeftHand.GetItem();
        LeftHand.Drop();
        var Ritem = RightHand.GetItem();
        RightHand.Drop();

        if (Litem)
        {
            RightHand.PickUp(Litem);
        }

        if (Ritem)
        {
            LeftHand.PickUp(Ritem);
        }
    }
}
