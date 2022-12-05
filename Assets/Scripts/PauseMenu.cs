using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Toggle toggle;

    public void Pause()
    {
        this._pausePanel.gameObject.SetActive(true);
    }

    public void Resume()
    {
        this._pausePanel.gameObject.SetActive(false);
    }

    public void Mute()
    {

        if(toggle.isOn)
        {
            MusicController.Instance.Mute(true);
        }
        else
        {
            MusicController.Instance.Mute(false);
        }

    }

    public void Exit()
    {
        Application.Quit();
    }
}
