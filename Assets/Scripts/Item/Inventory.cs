using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class Inventory : MonoBehaviour
        {
            public Item[] GetItems()
            {
                return GetComponentsInChildren<Item>();
            }
        }
    }
}