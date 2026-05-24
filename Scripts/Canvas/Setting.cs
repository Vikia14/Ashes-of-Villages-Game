using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Setting : MonoBehaviour
{
    public TMP_Dropdown _resolutionDropdown;
    public TMP_Dropdown _qualitiDropdown;

    Resolution[] _resolutions;
    private void Start()
    {
        _resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        _resolutions=Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i=0; i< _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height + " " + _resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);
            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex=i;
            }
        }
        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.RefreshShownValue();
        LoadSetting(currentResolutionIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

    }
    public void SetResolution(int resolutionindex)
    {
        Resolution _resolution = _resolutions [resolutionindex];
        Screen.SetResolution(_resolution.width, _resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SaveSetting()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", _qualitiDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", _resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }
    public void LoadSetting(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            _qualitiDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        }
        else
        {
            _qualitiDropdown.value = 3;
        }
        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            _resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        }
        else
        {
            _resolutionDropdown.value = currentResolutionIndex;
        }
        if (PlayerPrefs.HasKey("FullScreenPreference"))
        {
            Screen.fullScreen=System.Convert.ToBoolean((PlayerPrefs.GetInt("FullScreenPreference")));
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
