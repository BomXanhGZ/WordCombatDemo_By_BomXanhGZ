
using System.Collections.Generic;
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState;


public class LevelButton : MonoBehaviour
{
    public LevelButtonStruct button_data_                       { get; set; }

    /*references will be set by GameLevelWarpSpawnButton when Spawning the Button*/
    public GameManagerData ref_GameManagerData                  { get; set; }
    public BackGroundHandleBKGD ref_BackGroundHandleBKGD        { get; set; }
    public VocabularyLoader ref_VocabularyLoader                { get; set; }
    public VocabularyShower ref_VocabularyShower                { get; set; }
    public VocabularyQuizGenerator ref_VocabularyQuizGenerator  { get; set; }
    public AudioManagerSources ref_AudioManagerSources          { get; set; }
    public AudioManagerSFX ref_AudioManagerSFX                  { get; set; }
    public AudioManagerBGM ref_AudioManagerBGM                  { get; set; }
    public GameObject ref_GamePlayWarp                          { get; set; }
    public GameObject ref_GameLevelWarp                         { get; set; }
    

    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in LevelButton");
        CheckIsNotNull(ref_BackGroundHandleBKGD, "ref_BackGroundHandleBKGD in LevelButton");
        CheckIsNotNull(ref_VocabularyLoader, "ref_VocabularyLoader in LevelButton");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in LevelButton");
        CheckIsNotNull(ref_VocabularyQuizGenerator, "ref_VocabularyQuizGenerator in LevelButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in LevelButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in LevelButton");
        CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in LevelButton");
        CheckIsNotNull(ref_GamePlayWarp, "ref_GamePlayWarp in LevelButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in LevelButton");
    }

    public void OnClickLevelButton()
    {
        //Audio
        AudioClip start_game_sfx = ref_AudioManagerSources.SFX_click_start_game_;
        ref_AudioManagerSFX.PlaySFX(start_game_sfx);
        ref_AudioManagerBGM.PlayRandomBGM();

        //Get current_Level_idx
        ref_GameManagerData.level_idx_ = button_data_.level_index_;

        //Set Back Ground
        ref_BackGroundHandleBKGD.ShowBackGroundfromIdx(button_data_.level_index_);

        //load data level
        ref_VocabularyLoader.LoadCSV(button_data_.data_file_name_);

        //Set data VocabularyObject
        List<Vocabulary> l_rand_list = ref_VocabularyQuizGenerator.GetRandomizeList();
        ref_VocabularyShower.SetAnswerList(l_rand_list);
        
        //warp active
        ref_GamePlayWarp.SetActive(true);
        ref_GameLevelWarp.SetActive(false);

        //game state
        ref_GameManagerData.game_state_ = Intro;
    }
}
