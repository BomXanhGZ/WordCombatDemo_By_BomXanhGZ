
using System.Collections.Generic;
using UnityEngine;
using static GameUtility.Utility;
using static GameData.GameState;


public class LevelButton : MonoBehaviour
{
    public LevelButtonStruct button_data_                       { get; set; }

    public GameManagerData ref_GameManagerData                  { get; set; }
    public VocabularyLoader ref_VocabularyLoader                { get; set; }
    public VocabularyShower ref_VocabularyShower                { get; set; }
    public VocabularyQuizGenerator ref_VocabularyQuizGenerator  { get; set; }
    public GameObject ref_GamePlayWarp                          { get; set; }
    public GameObject ref_GameLevelWarp                         { get; set; }
    

    private void Start()
    {
        CheckIsNotNull(ref_VocabularyLoader, "ref_VocabularyLoader in LevelButton");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in LevelButton");
        CheckIsNotNull(ref_VocabularyQuizGenerator, "ref_VocabularyQuizGenerator in LevelButton");
        CheckIsNotNull(ref_GamePlayWarp, "ref_GamePlayWarp in LevelButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in LevelButton");
    }

    public void OnClickLevelButton()
    {

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
