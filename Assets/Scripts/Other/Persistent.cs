using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class Persistent : MonoBehaviour
        {
            void Start()
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}