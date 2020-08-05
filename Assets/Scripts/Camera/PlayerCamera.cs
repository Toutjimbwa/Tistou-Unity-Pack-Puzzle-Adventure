using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnityPackPuzzleAdventure
{
    public class PlayerCamera : CameraControl
    {
        private void Start()
        {
            _camera = GetComponentInChildren<Camera>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}