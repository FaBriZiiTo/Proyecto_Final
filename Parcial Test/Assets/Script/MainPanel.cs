using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;

    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    public float lastVolumen;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);  

        panel.SetActive(true);
        PlaySoundButton();


    }
    public void ChangeMasterVolumen(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeFXVolumen(float v)
    {
        mixer.SetFloat("VolFX", v);
    }

    public void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeFXVolumen);
        volumeMaster.onValueChanged.AddListener(ChangeMasterVolumen);
    }
    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }

    public void setMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolumen);
            mixer.SetFloat("VolMaster", -80);
        }
        else
            mixer.SetFloat("VolMaster", lastVolumen);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
