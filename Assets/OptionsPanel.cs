using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsPanel : MonoBehaviour
{
   [SerializeField] AudioManager audioManager;
   [SerializeField] Toggle muteToggle;
   [SerializeField] Slider bgmSlider;
   [SerializeField] Slider sfxSlider;
   [SerializeField] TMP_Text bgmVolText;
   [SerializeField] TMP_Text sfxVolText;

   private void OnEnable() 
   {
        muteToggle.isOn = audioManager.IsMute;
        bgmSlider.value = audioManager.BgmVolume;
        sfxSlider.value = audioManager.SfxVolume;
        SetBgmVolText (value: bgmSlider.value);
        SetSfxVolText (value: sfxSlider.value);
   }

   public void SetBgmVolText(float value)
   {
        bgmVolText.text = Mathf.RoundToInt (f: value * 100). ToString();
   }

   public void SetSfxVolText(float value)
   {
        sfxVolText.text = Mathf.RoundToInt (f: value * 100). ToString();
   }

}
