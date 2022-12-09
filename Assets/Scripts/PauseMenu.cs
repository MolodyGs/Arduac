using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Toggle toggle;

    private WaitForSeconds wait = new WaitForSeconds(0.01f);
    private const float SCALE = 0.1f;

    //Abre el panel de Pausa
    public void Pause(GameObject buttom)
    {
        
        this._pausePanel.gameObject.SetActive(true);
        MusicController.Instance.LowPassFilter(true); 
    
    }

    //Cierra el panel de Pausa
    public void Resume(GameObject buttom)
    {

        this._pausePanel.gameObject.SetActive(false);
        buttom.transform.localScale = new Vector3(buttom.transform.localScale.x - 4*SCALE, buttom.transform.localScale.y - 4*SCALE, buttom.transform.localScale.z - 4*SCALE);
        MusicController.Instance.LowPassFilter(false);
    
    }

    //Silencia la música
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

    //Cierra la aplicación
    public void Exit()
    {
        Application.Quit();
    }

    //Efecto de escala para los botones cuando el cursor está encima
    public void OnEnter(GameObject buttom)
    {
        StartCoroutine(Expansion(buttom, SCALE));
    }

    //Efecto de escala para los botones cuando el cursor sale del rango
    public void OnExit(GameObject buttom)
    {
        StartCoroutine(Expansion(buttom, -SCALE));
    }

    //Aumenta o disminuye la escala de un GameObject
    IEnumerator Expansion(GameObject buttom, float scale)
    {
        
        buttom.transform.localScale = new Vector3(buttom.transform.localScale.x + scale, buttom.transform.localScale.y + scale, buttom.transform.localScale.z + scale);
        yield return wait;
        buttom.transform.localScale = new Vector3(buttom.transform.localScale.x + scale, buttom.transform.localScale.y + scale, buttom.transform.localScale.z + scale);
        yield return wait;
        buttom.transform.localScale = new Vector3(buttom.transform.localScale.x + scale, buttom.transform.localScale.y + scale, buttom.transform.localScale.z + scale);
        yield return wait;
        buttom.transform.localScale = new Vector3(buttom.transform.localScale.x + scale, buttom.transform.localScale.y + scale, buttom.transform.localScale.z + scale);
    
    }

}
