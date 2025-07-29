
using UnityEngine;
using TMPro;
using static GameUtility.Utility;
using static GameData.SettingData;


public class LevelButtonSetText : MonoBehaviour
{
    bool first_enable_ = false;

    [SerializeField] LevelButton ref_LevelButton;
    [SerializeField] TextMeshProUGUI ref_LevelButtonText;
    [SerializeField] TextMeshProUGUI ref_TopScoreText;
    [SerializeField] TextMeshProUGUI ref_TopCorrectText;

    public DataBaseTemporary ref_DataBaseTemporary { get; set; }
    public GameManagerData ref_GameManagerData { get; set; }


    private void Start()
    {
        CheckIsNotNull(ref_LevelButton, "ref_LevelButton in LevelButtonSetText");
        CheckIsNotNull(ref_LevelButtonText, "ref_LevelButtonText in LevelButtonSetText");
        CheckIsNotNull(ref_TopScoreText, "ref_TopScoreText in LevelButtonSetText");
        CheckIsNotNull(ref_TopCorrectText, "ref_TopCorrectText in LevelButtonSetText");
        CheckIsNotNull(ref_DataBaseTemporary, "ref_DataBaseTemporary in LevelButtonSetText");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in LevelButtonSetText");
    }

    private void OnEnable()
    {
        if(!first_enable_)
        {
            first_enable_ = true;
            return;
        }

        SetLevelButtonText(ref_LevelButton.button_data_.level_index_);
    }

    public void SetLevelButtonText(int _level_idx)
    {
        //ButtonName
        string button_name = ref_LevelButton.button_data_.data_file_name_;
        if (button_name.Length >= 2)
        {
            string Textualize = button_name.Remove(0,3);         //remove idx_ in name file
            ref_LevelButtonText.text = Textualize;
        }
        else
        {
            Debug.Log("missing Button Name");
        }

        //HandleMaxValue
        int asw_counter = ref_GameManagerData.csv_files_[_level_idx - 1]          //all csv file at(lv_idx)
                            .text                                                 //all text
                            .Split( new[] { "\r\n", "\n" },                       //split text to lines
                                    System.StringSplitOptions.RemoveEmptyEntries)
                            .Length -1;                                           //line counter -1 title line
                                                                                   
        //TopScoreText
        int max_score = asw_counter * PERFECT_SCORE;
        int top_score = ref_DataBaseTemporary.GetTopScore(_level_idx);
        ref_TopScoreText.text = top_score.ToString() + "/" + max_score.ToString();

        //TopCorrectText
        int max_correct = asw_counter;
        int top_correct = ref_DataBaseTemporary.GetTopCorrect(_level_idx);
        ref_TopCorrectText.text = top_correct.ToString() + "/" + max_correct.ToString();
    }
}
