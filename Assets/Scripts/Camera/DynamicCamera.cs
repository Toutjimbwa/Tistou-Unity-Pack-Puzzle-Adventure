using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class DynamicCamera : MonoBehaviour
        {
            [SerializeField] private bool _lookAtPlayer = false;
            [SerializeField] private bool _followPlayer = false;
            private GameObject _player;
            private void Start()
            {
                _player = GameObject.FindWithTag("player");
            }
            void Update()
            {
                if (_lookAtPlayer) { LookAtPlayer(); }
                else if (_followPlayer) { FollowPlayer(); }
            }

            private void LookAtPlayer()
            {
                Debug.Log("look at player");
            }

            private void FollowPlayer()
            {
                Debug.Log("follow player");
            }
        }
    }
}