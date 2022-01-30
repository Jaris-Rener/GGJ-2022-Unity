using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFadeIn : MonoBehaviour
{
    private AudioSource _audioSource;

    private IEnumerator Start()
    {
        _audioSource = GetComponent<AudioSource>();
        yield return new WaitForSeconds(1);
        _audioSource.volume = 0;
        _audioSource.Play();
        _audioSource.DOFade(0.6f, 1.0f);
    }
}
