
using UnityEngine;
using static GameUtility.Utility;


public class GameLevelWarpSpawnButton : MonoBehaviour
{
    [SerializeField] Transform ref_ParentTransfrom;
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] BackGroundHandleBKGD ref_BackGroundHandleBKGD;
    [SerializeField] DataBaseTemporary ref_DataBaseTemporary;
    [SerializeField] VocabularyLoader ref_VocabularyLoader;
    [SerializeField] VocabularyShower ref_VocabularyShower;
    [SerializeField] VocabularyQuizGenerator ref_VocabularyQuizGenerator;
    [SerializeField] AudioManagerSources ref_AudioManagerSources;
    [SerializeField] AudioManagerSFX ref_AudioManagerSFX;
    [SerializeField] AudioManagerBGM ref_AudioManagerBGM;
    [SerializeField] GameObject ref_PrefabLevelButton;
    [SerializeField] GameObject ref_GamePlayWarp;
    [SerializeField] GameObject ref_GameLevelWarp;


    private void Start()
    {
        CheckIsNotNull(ref_ParentTransfrom, "ref_ParentTransfrom in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_BackGroundHandleBKGD, "ref_BackGroundHandleBKGD in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_DataBaseTemporary, "ref_DataBaseTemporary in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_VocabularyLoader, "ref_VocabularyLoaderin GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_VocabularyShower, "ref_VocabularyShower in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_VocabularyQuizGenerator, "ref_VocabularyQuizGenerator in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_AudioManagerSources, "ref_AudioManagerSources in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_AudioManagerSFX, "ref_AudioManagerSFX in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_AudioManagerBGM, "ref_AudioManagerBGM in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_PrefabLevelButton, "ref_PrefabLevelButton in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_GamePlayWarp, "ref_GamePlayWarp in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in GameLevelWarpSpawnButton");

        SpawnLevelButton();
    }

    void SpawnLevelButton()
    {

        for (int i = 0; i < ref_GameManagerData.csv_files_.Length; i++)
        {
            //spawn
            GameObject lv_button =  Instantiate(ref_PrefabLevelButton, new Vector3(),
                                    Quaternion.identity, ref_ParentTransfrom);




            //***BUTTON***-------------------------------------------
            LevelButton l_level_button = lv_button.GetComponent<LevelButton>();

            //button connect referens
            l_level_button.ref_GameManagerData = ref_GameManagerData;
            l_level_button.ref_BackGroundHandleBKGD = ref_BackGroundHandleBKGD;
            l_level_button.ref_VocabularyLoader = ref_VocabularyLoader;
            l_level_button.ref_VocabularyQuizGenerator = ref_VocabularyQuizGenerator;
            l_level_button.ref_VocabularyShower = ref_VocabularyShower;
            l_level_button.ref_AudioManagerSources = ref_AudioManagerSources;
            l_level_button.ref_AudioManagerSFX = ref_AudioManagerSFX;
            l_level_button.ref_AudioManagerBGM = ref_AudioManagerBGM;
            l_level_button.ref_GameLevelWarp = ref_GameLevelWarp;                           
            l_level_button.ref_GamePlayWarp = ref_GamePlayWarp;

            //button set data
            LevelButtonStruct button_data = new LevelButtonStruct();                       
            button_data.data_file_name_ = ref_GameManagerData.csv_files_[i].name;
            button_data.level_index_ = i + 1;                                           // +1 to idx start from 1
            l_level_button.button_data_ = button_data;



            //***BUTTON TEXT***--------------------------------------
            LevelButtonSetText button_text = l_level_button                                 
                                            .GetComponent<LevelButtonSetText>();
            //button text connect references
            button_text.ref_GameManagerData = ref_GameManagerData;
            button_text.ref_DataBaseTemporary = ref_DataBaseTemporary;

            //Set Text
            button_text.SetLevelButtonText(button_data.level_index_);
        }
    }
}
