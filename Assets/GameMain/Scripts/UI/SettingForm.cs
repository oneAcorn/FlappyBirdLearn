using FlappyBird;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingForm : UGuiForm
{

    public void OnCloseBtnClick()
    {
        Close();
    }

    public void OnMusicSettingValueChange(Slider slider)
    {
        //Debug.Log($"volume:{GameEntry.Sound.GetVolume("Music")}");
        GameEntry.Sound.SetVolume("Music", slider.value);
    }

    public void OnSoundSettingValueChange(Slider slider)
    {
        GameEntry.Sound.SetVolume("Sound", slider.value);
        GameEntry.Sound.SetVolume("UISound", slider.value);
    }
}
