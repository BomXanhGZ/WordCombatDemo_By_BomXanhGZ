
using UnityEngine;
using static GameUtility.Utility;


public class SettingButton : MonoBehaviour
{
    [SerializeField] GameObject ref_SettingPanel;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;

    private void Start()
    {
        CheckIsNotNull(ref_SettingPanel, "ref_SettingPanel in SettingButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in SettingButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in SettingButton");
    }

    public void OnclickSettingButton()
    {
        ref_AudioManagerSFX.PlaySFX(ref_AudioManagerSources.SFX_click_);
        ref_SettingPanel.SetActive(true);
    }
}
