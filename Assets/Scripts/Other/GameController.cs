using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class GameController : MonoBehaviour
        {
            private static GameController _gameController = null;
            void Awake()
            {
                if (!_gameController)
                {
                    _gameController = this;
                    DontDestroyOnLoad(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}