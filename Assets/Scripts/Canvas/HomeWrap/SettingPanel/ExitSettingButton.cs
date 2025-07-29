
using UnityEngine;
using static GameUtility.Utility;


public class ExitSettingButton : MonoBehaviour
{
    [SerializeField] GameObject ref_SettingPanel;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;


    private void Start()
    {
        CheckIsNotNull(ref_SettingPanel, "ref_SettingPanel in ExitSettingButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in ExitSettingButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in ExitSettingButton");
    }

    public void OnclickExitSettingButton()
    {
        ref_AudioManagerSFX.PlaySFX( ref_AudioManagerSources.SFX_click_ );
        ref_SettingPanel.SetActive(false);
    }
}
