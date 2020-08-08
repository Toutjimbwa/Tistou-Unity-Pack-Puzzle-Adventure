using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class CameraAreaTrigger : MonoBehaviour
        {
            private void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.tag == "Player")
                {
                    GetComponentInParent<CameraArea>().PlayerEnteredArea();
                }
            }
            private void OnTriggerExit(Collider other)
            {
                if (other.gameObject.tag == "Player")
                {
                    GetComponentInParent<CameraArea>().PlayerExitedArea();
                }
            }
        }
    }
}