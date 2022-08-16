using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource titleScreenMusic, levelMusic;
    public AudioSource[] sfx;

    public void PlayTitleScreenMusic()
    {
        
          levelMusic.Stop();
          titleScreenMusic.Play();
        
    }

    public void PlayLevelMusic()
    {
        if (!levelMusic.isPlaying)
        {
            titleScreenMusic.Stop();
            levelMusic.Play();
        }
    }    

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();  
    }
}
