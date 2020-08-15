using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public abstract class Interactable : MonoBehaviour
        {
            public abstract void Focus();
            public abstract void UnFocus();
            public abstract void Pick();
        }
    }
}