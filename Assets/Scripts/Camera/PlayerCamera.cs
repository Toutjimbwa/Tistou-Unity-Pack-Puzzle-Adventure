using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class PlayerCamera : CameraControl
        {
            private void Start()
            {
                _camera = GetComponent<Camera>();
                Add(this);

                SelectCameraControl();
            }
        }
    }
}