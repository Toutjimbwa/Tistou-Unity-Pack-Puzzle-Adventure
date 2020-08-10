using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public enum AdventureState
        {
            Hidden,
            Available,
            Started,
            Done
        }
        public class Adventure : MonoBehaviour
        {
            public string Subject;
            [TextArea] public string Summary;
            public AdventureState State = AdventureState.Hidden;
        }
    }
}