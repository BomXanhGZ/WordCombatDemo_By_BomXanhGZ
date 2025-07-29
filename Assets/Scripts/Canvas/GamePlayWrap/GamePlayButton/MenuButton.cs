
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState
    ;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameObject ref_GamePlaySpace;
    [SerializeField] GameObject ref_GameMenuSpace;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerBGM ref_AudioManagerBGM;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in MenuButton");
        CheckIsNotNull(ref_GamePlaySpace, "ref_GamePlaySpace in MenuButton");
        CheckIsNotNull(ref_GameMenuSpace, "ref_GameMenuSpace in MenuButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in MenuButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in MenuButton");
        CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in MenuButton");
    }


    /*PAUSE GAME*/
    public void OnClickMenuButton()
    {
        //Audio
        AudioClip click_sfx = ref_AudioManagerSources.SFX_click_;               //sfx
        ref_AudioManagerSFX.PlaySFX(click_sfx);

        AudioSource ref_BGM_channel_ = ref_AudioManagerBGM.GetBGM_Channel();    //bgm
        ref_BGM_channel_.Pause();

        //pause Setting
        ref_GameManagerData.last_state = ref_GameManagerData.game_state_;
        ref_GameManagerData.game_state_ = IsPause;
        Time.timeScale = 0;

        //panel state
        ref_GameMenuSpace.SetActive(true);
        ref_GamePlaySpace.SetActive(false);
    }
}
