using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAbility : MonoBehaviour
{
    public KeyCode TalkButton = KeyCode.T;
    public Talk _talk;
    public TalkController _talkController;
    public RJHand RightHand;
    private void Update()
    {
        if (Input.GetKeyDown(TalkButton))
        {
            if (_talk)
            {
                _talkController.StartTalk(_talk, RightHand.GetItem());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        var talk = other.GetComponentInChildren<Talk>();
        if (talk && !talk.Equals(_talk))
        {
            _talk = talk;
            _talk.Focus();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        var talk = other.GetComponentInChildren<Talk>();
        if (talk && talk.Equals(_talk))
        {
            _talk.Unfocus();
            _talk = null;
        }
    }
}