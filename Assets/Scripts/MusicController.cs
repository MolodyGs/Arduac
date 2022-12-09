using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceFx; 
    [SerializeField] private AudioMixer _mixer;
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

    //Sonido árbol
    public void TreeFx()
    {
        _audioSourceFx.Play();
    }

    //la música deja de estar pausada
    public void UnpauseMusic()
    {
        _audioSourceMusic.UnPause();
    }

    //Pausa la música
    public void PauseMusic()
    {
        _audioSourceMusic.Pause();
    }

    //Mutea la música
    public void Mute(bool mute)
    {
        _mixer.SetFloat("MixerVolumen", mute ? -80 : -15);
    }

    //Efecto low pass para el menu de pausa
    public void LowPassFilter(bool active)
    {
        _mixer.SetFloat("LowPass", active ? 1000 : 10000);
    }

}
