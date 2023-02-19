using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // 오디오 소스가 사용하는 오디오 데이터 등
    public AudioClip bgmSound;
    // 씬에서 오디오 클립 재생
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
