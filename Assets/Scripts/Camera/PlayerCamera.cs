using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class PlayerCamera : CameraControl
        {
            private void OnEnable()
            {
                LoadCamera();
            }
            private void LoadCamera()
            {
                _camera = GetComponent<Camera>();
                _audioListener = GetComponent<AudioListener>();
                Add(this);
            }
        }
    }
}