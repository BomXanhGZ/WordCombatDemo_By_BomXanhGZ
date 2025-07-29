
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using static GameUtility.Utility;
using static DataBaseKeyName;
using System.Collections.Generic;


public class DataBaseQuery : MonoBehaviour
{
    [SerializeField] DataBaseConnector ref_DataBaseConnector;

    private void Start()
    {
        CheckIsNotNull(ref_DataBaseConnector, "ref_DataBaseConnector in DataBaseQuery");
    }

    public List<DataStruct> GetDataBase(string _table_name)
    {
        string sql = "SELECT * FROM " + _table_name;
        List<DataStruct> data_list = new List<DataStruct>();

        using (var cmd = new SqliteCommand(sql, ref_DataBaseConnector.GetDBConnect) )
        {
            using ( var reader = cmd.ExecuteReader() )
            {
                while( reader.Read() )
                {
                    DataStruct data = new DataStruct();
                    data.level_idx_ = reader.GetInt32(0);
                    data.top_ans_ = reader.GetInt32(1);
                    data.score_ = reader.GetInt32(2);

                    data_list.Add(data);
                }
            }
        }

        return data_list;
    }

    public void InsertData(string tb_name, int _score = 0, int _top_ans = 0)
    {
        string sql =    "INSERT INTO " + tb_name + "(" + SCORE + ", " + TOP_ANS + ") "
                        + "VALUES " + "(@" + SCORE + ", @" + TOP_ANS + ")";

        try
        {
            using (var cmd = new SqliteCommand(sql, ref_DataBaseConnector.GetDBConnect))
            {
                cmd.Parameters.AddWithValue("@" + SCORE, _score);
                cmd.Parameters.AddWithValue("@" + TOP_ANS, _top_ans);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public void UpdateData(string _tb_name, int _lv_idx, int _score, int _top_ans)
    {
        string sql = "UPDATE " + _tb_name + " SET "
                        + SCORE + "=@" + SCORE + ", "
                        + TOP_ANS + "=@" + TOP_ANS +
                        " WHERE " + LEVLE_IDX + "=@" + LEVLE_IDX;

        try
        {
            using (var cmd = new SqliteCommand(sql, ref_DataBaseConnector.GetDBConnect) )
            {
                cmd.Parameters.AddWithValue("@" + SCORE, _score);
                cmd.Parameters.AddWithValue("@" + TOP_ANS , _top_ans);
                cmd.Parameters.AddWithValue("@" + LEVLE_IDX, _lv_idx);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
