using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnityPackPuzzleAdventure
{
    public class DynamicCamera : MonoBehaviour
    {
        [SerializeField] private bool Look_At_Player = false;
        [SerializeField] private bool Follow_Player = false;
        private GameObject player;

        void Update()
        {
            if (Look_At_Player){LookAtPlayer();}
            else if (Follow_Player){FollowPlayer();}
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