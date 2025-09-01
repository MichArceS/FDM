using UnityEngine;
using TMPro;
using System.Collections;

public class TriggerAudio : MonoBehaviour
{
    public AudioClip audioClip;
    public bool flag;

    private void Start()
    {
        flag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && flag)
        {
            StartCoroutine(EnumeratorAudio());
            flag = false;
        }
    }

    IEnumerator EnumeratorAudio()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(audioClip.length);
        flag = true;
    }
}
