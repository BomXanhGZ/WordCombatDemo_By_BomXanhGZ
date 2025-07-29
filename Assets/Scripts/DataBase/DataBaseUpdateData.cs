
using System;
using UnityEngine;
using static GameUtility.Utility;

public class DataBaseUpdateData : MonoBehaviour
{
    [SerializeField] DataBaseTemporary ref_DataBaseTemporary;
    [SerializeField] DataBaseQuery ref_DataBaseQuery;

    private void Start()
    {
        CheckIsNotNull(ref_DataBaseQuery, "ref_DataBaseQuery in DataBaseUpdateData");
        CheckIsNotNull(ref_DataBaseTemporary, "ref_DataBaseTemporary in DataBaseUpdateData");
    }

    public void UpdateDataBase(int _lv_idx, int _score, int _correct_ans)
    {
        //compare score
        int current_top_score = ref_DataBaseTemporary.temp_data_[_lv_idx].score_;
        int current_top_ans = ref_DataBaseTemporary.temp_data_[_lv_idx].top_ans_;

        if (current_top_score >= _score && current_top_ans >= _correct_ans)
        return;

        //Update DataBaseTemporary
        DataStruct new_data = new DataStruct(_lv_idx, _score, _correct_ans);
        ref_DataBaseTemporary.temp_data_[_lv_idx] = new_data;

        //Update DataBase
        ref_DataBaseQuery.UpdateData( ref_DataBaseTemporary.current_table_name_,
                                      _lv_idx, _score, _correct_ans);
    }

}
