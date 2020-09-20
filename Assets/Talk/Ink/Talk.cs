using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public TextAsset inkJSONAsset = null;

    public void Focus()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void Unfocus()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}