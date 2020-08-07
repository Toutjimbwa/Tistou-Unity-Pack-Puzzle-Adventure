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
            }
            private void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.tag == "Player")
                {
                    Add(this);
                }
            }

            private void OnTriggerExit(Collider other)
            {
                if (other.gameObject.tag == "Player")
                {
                    Remove(this);
                }
            }
        }
    }
}