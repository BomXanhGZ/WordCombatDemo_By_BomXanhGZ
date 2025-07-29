
using UnityEngine;
using UnityEngine.UI;
using static GameUtility.Utility;
using static LocalData;


public class BGMSlider : MonoBehaviour
{
    [SerializeField] Slider ref_BGMSlider;
    [SerializeField] AudioManagerBGM ref_AudioManagerBGM;
    private AudioSource ref_BGM_channel;


    private void Start()
    {
        bool is_not_null = false;

        //BGM Channel
        is_not_null = CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in BGMSlider");
        if (is_not_null)
        {
            ref_BGM_channel = ref_AudioManagerBGM.GetBGM_Channel();
        }

        //BGM Slider
        is_not_null = CheckIsNotNull(ref_BGMSlider, "ref_BGMSlider in BGMSlider");
        if(is_not_null && ref_BGM_channel)
        {
            //sub event
            ref_BGMSlider.onValueChanged.AddListener(SetBGMVolume);

            //Slider Value
            ref_BGMSlider.value = ref_AudioManagerBGM.GetBGM_Channel().volume;
        }
    }

    void SetBGMVolume(float _bgm_vol_val)
    {
        ref_BGM_channel.volume = _bgm_vol_val;

        //save into PlayerPrefs
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, _bgm_vol_val);
    }
}
