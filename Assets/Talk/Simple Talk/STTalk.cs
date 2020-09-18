using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STTalk : MonoBehaviour
{
    public GameObject UIDialogue;
    public GameObject TalkButton;

    [TextArea] public string comment;

    public void Run()
    {
        UIDialogue.GetComponentInChildren<Text>().text = comment;
        UIDialogue.SetActive(true);
    }
    public void Bye()
    {
        UIDialogue.GetComponentInChildren<Text>().text = "";
        UIDialogue.SetActive(false);
    }
    public void ShowKey()
    {
        float x = transform.position.x;
        float y = transform.position.y + 1.7f;
        float z = transform.position.z;
        TalkButton.transform.position = new Vector3(x, y, z);
        TalkButton.SetActive(true);
    }

    public void HideKey()
    {
        TalkButton.SetActive(false);
    }
}
