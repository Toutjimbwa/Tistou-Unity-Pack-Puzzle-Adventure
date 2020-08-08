using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class CameraArea : CameraControl
        {
            private void Start()
            {
                _camera = GetComponentInChildren<Camera>();
                _audioListener = GetComponentInChildren<AudioListener>();
            }
            public void PlayerEnteredArea()
            {
                Add(this);
            }
            public void PlayerExitedArea()
            {
                Remove(this);
            }
        }
    }
}