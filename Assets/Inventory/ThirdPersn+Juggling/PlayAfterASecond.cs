using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAfterASecond : MonoBehaviour
{
    public AudioSource sound;
    public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAfterSeconds(delay));
    }

    IEnumerator PlayAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sound.Play();
    }
}
