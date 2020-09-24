using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeOnce : MonoBehaviour
{
    public GameObject NPCGiveYouItem;
    public RJItem YouGiveNPCItem;
    public string comment;
    public RJHand RightHand;
    public bool Trade(RJItem YouGiveNPC)
    {
        if(YouGiveNPC && YouGiveNPC.name.Equals(YouGiveNPCItem.name))
        {
            GivePlayerItem();
            return true;
        }
        return false;
    }
    void GivePlayerItem()
    {
        RJItem NPCTakesitem = RightHand.GetItem();
        RightHand.Drop();
        Destroy(NPCTakesitem.gameObject);

        GameObject NPCGivesGO = Instantiate(NPCGiveYouItem, transform, false);
        NPCGivesGO.transform.localPosition = new Vector3(0, 0, 0);
        RightHand.PickUp(NPCGivesGO.GetComponent<RJItem>());
    }
}
