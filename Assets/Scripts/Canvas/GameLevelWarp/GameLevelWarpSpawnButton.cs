
using UnityEngine;
using static GameUtility.Utility;


public class GameLevelWarpSpawnButton : MonoBehaviour
{
    //Setting
    readonly Vector2 START_POINT = new Vector2(-7.0f, 3.0f);
    readonly Vector2 BUTTON_SPACE = new Vector2(2.0f, 1.5f);

    //reference
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] VocabularyLoader ref_VocabularyLoader;
    [SerializeField] VocabularyShower ref_VocabularyShower;
    [SerializeField] VocabularyQuizGenerator ref_VocabularyQuizGenerator;
    [SerializeField] GameObject ref_PrefabLevelButton;
    [SerializeField] GameObject ref_GamePlayWarp;
    [SerializeField] GameObject ref_GameLevelWarp;


    private void Start()
    {
        CheckIsNotNull(ref_PrefabLevelButton, "ref_PrefabLevelButton in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_GamePlayWarp, "ref_GamePlayWarp in GameLevelWarpSpawnButton");
        CheckIsNotNull(ref_GameLevelWarp, "ref_GameLevelWarp in GameLevelWarpSpawnButton");

        SpawnLevelButton();
    }

    void SpawnLevelButton()
    {
        Vector2 button_pos = START_POINT;

        for (int i = 0; i < ref_GameManagerData.csv_files_.Length; i++)
        {
            //spawn
            GameObject lv_button =  Instantiate(ref_PrefabLevelButton, button_pos,
                                    Quaternion.identity, this.transform);


            //handle data
            LevelButton l_level_button = lv_button.GetComponent<LevelButton>();         

            l_level_button.ref_GameLevelWarp = ref_GameLevelWarp;                           //ref
            l_level_button.ref_GamePlayWarp = ref_GamePlayWarp;
            l_level_button.ref_GameManagerData = ref_GameManagerData;
            l_level_button.ref_VocabularyLoader = ref_VocabularyLoader;
            l_level_button.ref_VocabularyQuizGenerator = ref_VocabularyQuizGenerator;
            l_level_button.ref_VocabularyShower = ref_VocabularyShower;
            
            LevelButtonStruct button_data = new LevelButtonStruct();                        //button data
            button_data.data_file_name_ = ref_GameManagerData.csv_files_[i].name;
            button_data.level_index_ = i;
            l_level_button.button_data_ = button_data;

            LevelButtonSetText button_text = l_level_button                                 //Button Text
                                            .GetComponent<LevelButtonSetText>();
            button_text.SetLevelButtonText();


            //Handle next button Pos
            button_pos.x += BUTTON_SPACE.x;

            if( (i + 1) % 5 == 0 )                  //1 row only 5 button
            {
                button_pos.y -= BUTTON_SPACE.y;
                button_pos.x = START_POINT.x;
            }
        }
    }
}
