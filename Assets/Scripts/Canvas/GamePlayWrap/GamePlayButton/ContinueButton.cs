
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState;
using GameData;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameMenuSpace;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerBGM ref_AudioManagerBGM;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in ContinueButton");
        CheckIsNotNull(ref_GamePlaySpace, "ref_GamePlaySpace in ContinueButton");
        CheckIsNotNull(ref_GameMenuSpace, "ref_GameMenuSpace in ContinueButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in ContinueButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in ContinueButton");
        CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in ContinueButton");
    }

    /*UNPAUSE GAME*/
    public void OnClickContinueButton()
    {
        //Audio
        AudioClip click_sfx = ref_AudioManagerSources.SFX_click_;               //sfx
        ref_AudioManagerSFX.PlaySFX(click_sfx);

        AudioSource ref_BGM_channel_ = ref_AudioManagerBGM.GetBGM_Channel();    //bgm
        ref_BGM_channel_.UnPause();

        //UnPause Setting
        GameState prew_state = ref_GameManagerData.last_state;                  //Intro or IsPlay
        ref_GameManagerData.game_state_ = prew_state;                           
        Time.timeScale = 1.0f;

        //panel active
        ref_GamePlaySpace.SetActive(true);
        ref_GameMenuSpace.SetActive(false);
    }
}
