using UnityEngine;
using UnityEngine.SceneManagement;

namespace TistouUnity
{
    namespace PuzzleAdventurePack
    {
        public class Warp : MonoBehaviour
        {
            [SerializeField] private GameObject _playerPrefab = null;
            [SceneName] public string EnterScene;
            [SerializeField] private WarpTag _warpTag = WarpTag.A;
            private Transform _enterPoint;
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
                    DontDestroyOnLoad(gameObject);
                    SceneManager.sceneLoaded += InstantiatePlayer;
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
            private void InstantiatePlayer(Scene scene, LoadSceneMode mode)
            {
                SceneManager.sceneLoaded -= InstantiatePlayer;
                var player = GameObject.FindGameObjectWithTag("Player");
                if (!player)
                {
                    player = Instantiate(_playerPrefab);
                }
                player.GetComponent<Disableable>().DisableComponentsButNotTransform();
                var exit = FindWarpExit();
                player.transform.position = exit._enterPoint.transform.position;
                player.transform.rotation = exit._enterPoint.transform.rotation;
                player.GetComponent<Disableable>().EnableComponentsButNotTransform();
                Destroy(gameObject);
            }
        }
    }
}