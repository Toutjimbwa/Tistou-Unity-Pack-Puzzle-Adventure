using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class PlayerStart : MonoBehaviour
        {
            [SerializeField] private GameObject _player = null;
            void Start()
            {
                if( !GameObject.FindGameObjectWithTag("Player"))
                {
                    var player = Instantiate(_player);
                    player.GetComponent<CharacterController>().enabled = false;
                    player.transform.position = transform.position;
                    player.transform.rotation = transform.rotation;
                    player.GetComponent<CharacterController>().enabled = true;
                }
            }
        }
    }
}