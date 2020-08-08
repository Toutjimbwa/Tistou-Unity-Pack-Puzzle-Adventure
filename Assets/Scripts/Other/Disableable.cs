using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class Disableable : MonoBehaviour
        {
            public void DisableComponentsButNotTransform()
            {
                MonoBehaviour[] components = GetComponents<MonoBehaviour>();
                foreach(var c in components)
                {
                    if (!c.Equals(this))
                    {
                        c.enabled = false;
                    }
                }
                GetComponent<CharacterController>().enabled = false;
            }
            public void EnableComponentsButNotTransform()
            {
                MonoBehaviour[] components = GetComponents<MonoBehaviour>();
                foreach (var c in components)
                {
                    if (!c.Equals(this))
                    {
                        c.enabled = true;
                    }
                }
                GetComponent<CharacterController>().enabled = true;
            }
        }
    }
}