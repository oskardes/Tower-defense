using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    private AudioSource sorce;
    [SerializeField] private GameObject muted;

    private void Start()
    {
        sorce = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadValue();
        }
        else
        {
            LoadValue();
        }

    }

    public static VolumeMager _instance = null;
    private static VolumeMager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    void LoadValue()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void MuteSound()
    {
        if (sorce.isPlaying)
        {
            muted.SetActive(true);
            sorce.Pause();
        }
        else
        {
            muted.SetActive(false);
            sorce.Play();
        }
    }
}
