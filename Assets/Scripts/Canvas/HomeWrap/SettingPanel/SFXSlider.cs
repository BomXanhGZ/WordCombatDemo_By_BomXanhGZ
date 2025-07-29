
using UnityEngine;
using UnityEngine.UI;
using static GameUtility.Utility;
using static LocalData;


public class SFXSlider : MonoBehaviour
{
    [SerializeField] Slider ref_SFXSlider;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    private AudioSource ref_SFX_channel;


    private void Start()
    {
        bool is_not_null = true;

        //SFX Channel
        is_not_null =  CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in SFXSlider");
        if (is_not_null)
        {
            ref_SFX_channel = ref_AudioManagerSFX.GetSFX_Channel();
        }

        //SFX Slider
        is_not_null = CheckIsNotNull(ref_SFXSlider, "ref_SFXSlider in SFXSlider");
        if (is_not_null && ref_SFX_channel) 
        {
            //sub event
            ref_SFXSlider.onValueChanged.AddListener(SetSFXVolume);

            //Slider Value
            ref_SFXSlider.value = ref_AudioManagerSFX.GetSFX_Channel().volume;
        }
    }

    void SetSFXVolume(float _sfx_vol_val)
    {
        ref_SFX_channel.volume = _sfx_vol_val;

        //save into PlayerPrefs
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, _sfx_vol_val);
    }
}
