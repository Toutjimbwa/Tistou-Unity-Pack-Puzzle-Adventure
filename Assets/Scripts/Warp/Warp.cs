using UnityEngine;
using UnityEngine.SceneManagement;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class Warp : MonoBehaviour
        {
            [SceneName] public string EnterScene;
            [SerializeField] private WarpTag _warpTag = WarpTag.A;
            private Transform _enterPoint;
            private GameObject _player;
            private void OnEnable()
            {
                transform.parent = null;
                foreach(Transform child in transform)
                {
                    if(child.tag.Equals("EnterPoint"))
                    {
                        _enterPoint = child;
                        break;
                    }
                }
            }
            private void OnTriggerEnter(Collider other)
            {
                if (other.CompareTag("Player"))
                {
                    GetComponent<Collider>().enabled = false;
                    _player = GameObject.FindGameObjectWithTag("Player");
                    _player.SetActive(false);
                    SceneManager.sceneLoaded += PlacePlayer;
                    SceneManager.LoadScene(EnterScene);
                }
            }
            private Warp FindWarpExit()
            {
                Warp[] warps = FindObjectsOfType<Warp>();
                foreach (var w in warps)
                {
                    if (w._warpTag.Equals(_warpTag))
                    {
                        if (!w.Equals(this))
                        {
                            return w;
                        }
                    }
                }
                return null;
            }
            private void PlacePlayer(Scene scene, LoadSceneMode mode)
            {
                SceneManager.sceneLoaded -= PlacePlayer;
                var exit = FindWarpExit();
                _player.transform.position = exit._enterPoint.transform.position;
                _player.transform.rotation = exit._enterPoint.transform.rotation;
                _player.SetActive(true);
            }
        }
    }
}