
using UnityEngine;
using TMPro;
using static GameUtility.Utility;


public class LevelButtonSetText : MonoBehaviour
{
    const string BUTTON_TITLE = "Lv ";

    [SerializeField] LevelButton ref_LevelButton;
    [SerializeField] TextMeshProUGUI ref_LevelButtonText;


    private void Start()
    {
        CheckIsNotNull(ref_LevelButton, "ref_LevelButton in LevelButtonSetText");
        CheckIsNotNull(ref_LevelButtonText, "ref_LevelButtonText in LevelButtonSetText");
    }

    public void SetLevelButtonText()
    {
        //get idx
        int button_idx = ref_LevelButton.button_data_.level_index_ + 1;     //+1 offset array index

        //if ok
        if (button_idx > 0)
        {
            string Textualize = BUTTON_TITLE + button_idx.ToString();
            ref_LevelButtonText.text = Textualize;

            return;
        }

        //if err
        Debug.Log("NUll _leve_text");
    }
}
