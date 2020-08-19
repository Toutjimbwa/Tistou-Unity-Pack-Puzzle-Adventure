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
            private void Start()
            {
                SceneManager.sceneLoaded += LoadCamera;
                LoadCamera();
            }
            private void LoadCamera(Scene scene, LoadSceneMode mode)
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