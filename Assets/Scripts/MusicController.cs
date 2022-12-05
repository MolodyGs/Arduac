using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceFx; 
    [SerializeField] private List<AudioClip> _clips;

    private void Awake()
    {
        
        Initialization();

    }

    private void Initialization()
    {

        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        _audioSourceFx.clip = _clips[1];

        _audioSourceMusic.clip = _clips[0];
        _audioSourceMusic.Play();
        _audioSourceMusic.Pause();
        
    }

    public void TreeFx()
    {
        _audioSourceFx.Play();
    }

    public void UnpauseMusic()
    {
        _audioSourceMusic.UnPause();
    }

    public void PauseMusic()
    {
        _audioSourceMusic.Pause();
    }

    public void Mute(bool mute)
    {

        float volumen = mute ? 0 : 0.5f;

        this._audioSourceFx.volume = volumen;
        this._audioSourceMusic.volume = volumen;
        
    }

}
