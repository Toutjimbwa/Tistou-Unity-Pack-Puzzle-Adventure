using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STTalkAbility : MonoBehaviour
{
    public KeyCode TalkKey = KeyCode.E;

    public STTalk possibleTalk;
    public STTalk _talkingTalk;
    private void Update()
    {
        if (possibleTalk)
        {
            if (Input.GetKeyDown(TalkKey))
            {
                possibleTalk.HideKey();
                _talkingTalk = possibleTalk;
                possibleTalk = null;
                _talkingTalk.Run();
            }
        }
        else if (_talkingTalk)
        {
            if (Input.GetKeyDown(TalkKey))
            {
                _talkingTalk.Bye();
                possibleTalk = _talkingTalk;
                _talkingTalk = null;
                possibleTalk.ShowKey();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        STTalk t = other.GetComponent<STTalk>();
        if (t)
        {
            possibleTalk = t;
            t.ShowKey();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        STTalk t = other.GetComponent<STTalk>();
        if (t)
        {
            if (t.Equals(possibleTalk))
            {
                t.HideKey();
                possibleTalk = null;
            }
            if (t.Equals(_talkingTalk))
            {
                t.Bye();
                _talkingTalk = null;
            }
        }
    }
}
