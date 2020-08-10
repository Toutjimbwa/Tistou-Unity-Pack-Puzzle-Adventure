using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class DialogueControl : MonoBehaviour
        {
            public void OpenDialogue()
            {
                //Setup for a dialogue, open UI etc.
                //Multiple choices should be available.
            }
            public void Say(string name, string text)
            {
                Debug.Log($"{name}: {text}");
            }
        }
    }
}