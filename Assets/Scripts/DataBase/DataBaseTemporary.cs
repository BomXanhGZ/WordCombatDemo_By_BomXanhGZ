
using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameUtility.Utility;


public class DataBaseTemporary : MonoBehaviour
{
    //current table name
    public string current_table_name_ { get; set; }

    //TempDataBase
    public List<DataStruct> temp_data_ { set; get; }                //real data start from idx 1 

    //Reference
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] DataBaseQuery ref_DataBaseQuery;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in DataBaseTemporary");
        CheckIsNotNull(ref_DataBaseQuery, "ref_DataBaseQuery in DataBaseTemporary");

        StartCoroutine( WaitOneFram() );
    }

    private IEnumerator WaitOneFram()
    {
        yield return null;

        LoadDataBase();
    }

    public void LoadDataBase()
    {

        //table name from Game Mode
        SetCurrentTableNameWithGameMode(ref_GameManagerData.game_mode_);

        //set Temporary DataBase for Handle synchronize
        temp_data_ = ref_DataBaseQuery.GetDataBase(current_table_name_);

        //Handle synchronize Data
        var syncLevelFromResource = new SyncLevelFromResource();
        syncLevelFromResource.SyncData(ref_GameManagerData, ref_DataBaseQuery, this);

        //set Temporary DataBase
        temp_data_ = ref_DataBaseQuery.GetDataBase(current_table_name_);
        temp_data_.Insert(0, new DataStruct() );                       //for real data start from idx 1 
    }

    public int GetTopScore(int _level_idx)
    {
        if(_level_idx <= 0)
        {
            Debug.LogError("Missing entry: element index does not exist");
            Debug.LogError("missing element index must > 0");
            return -1;
        }

        foreach(var level in temp_data_)
        {
            if(level.level_idx_ == _level_idx)
            {
                return level.score_;
            }
        }

        Debug.LogError("Missing entry: element index does not exist");
        return -1;
    }

    public int GetTopCorrect(int _level_idx)
    {

        if (_level_idx <= 0)
        {
            Debug.LogError("Missing entry: element index does not exist");
            Debug.LogError("missing element index must > 0");
            return -1;
        }

        foreach (var level in temp_data_)
        {
            if (level.level_idx_ == _level_idx)
            {
                return level.top_ans_;
            }
        }

        Debug.LogError("Missing entry: element index does not exist");
        return -1;
    }

    void SetCurrentTableNameWithGameMode(GameMode _mode)
    {
        if (_mode == GameMode.Reading)
        {
            current_table_name_ = DataBaseKeyName.READING_MODE_TABLE_NAME;
        }
        else if (_mode == GameMode.Meaning)
        {
            current_table_name_ = DataBaseKeyName.MEANING_MODE_TABLE_NAME;
        }
    }
}
