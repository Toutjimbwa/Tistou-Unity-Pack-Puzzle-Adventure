using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class ThereCanBeOnlyOne : MonoBehaviour
        {
            private static GameObject _theOne = null;

            private void Start()
            {
                if (_theOne)
                {
                    Destroy(gameObject);
                }
                else
                {
                    _theOne = gameObject;

                }
                Debug.Log($"{gameObject.name}: {_theOne.name}");
            }
        }
    }
}