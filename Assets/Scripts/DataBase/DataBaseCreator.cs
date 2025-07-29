
using UnityEngine;
using Mono.Data.Sqlite;
using static DataBaseKeyName;

public class DataBaseCreator
{
    public void CreateDbFile(ref SqliteConnection _db_cnn, string _path)
    {
        //create file
        _db_cnn = new SqliteConnection(_path);          //reference and create new db
        _db_cnn.Open();
        if(_db_cnn == null)
        {
            Debug.Log("create db file failed");
            return;
        }

        Debug.Log("create db file success");

        //create table
        CreateTable(_db_cnn, READING_MODE_TABLE_NAME);
        CreateTable(_db_cnn, MEANING_MODE_TABLE_NAME);
    }

    public void CreateTable(SqliteConnection _db_cnn, string _tb_name)
    {
        if( _db_cnn == null )
        {
            Debug.LogError("db_connection null at CreateTable");
            return;
        }

        using (var create_table_cmd = _db_cnn.CreateCommand())
        {
            create_table_cmd.CommandText = 
                "CREATE TABLE IF NOT EXISTS" 
                + " " + _tb_name + " " + "("
                + " " + LEVLE_IDX  + " INTEGER PRIMARY KEY AUTOINCREMENT," 
                + " " + TOP_ANS    + " DEFAULT 0," 
                + " " + SCORE      + " DEFAULT 0"
                + ")";

            create_table_cmd.ExecuteNonQuery();
            Debug.Log("create Table was success");
        }
    }
}
