using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class CameraMaster : CameraControl
        {
            private void Start()
            {
                SceneManager.sceneLoaded += ResetCameras;
                ResetCameras();
            }
            private void ResetCameras(Scene scene, LoadSceneMode mode)
            {
                ResetReadyControls();
            }
            private void ResetCameras()
            {
                ResetReadyControls();
            }
        }
    }
}