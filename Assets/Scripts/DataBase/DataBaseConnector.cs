
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using static GameUtility.Utility;


public class DataBaseConnector : MonoBehaviour
{
    const string db_name_ = "dbgame.db";
    string db_path_;

    private SqliteConnection db_connector_;
    public  SqliteConnection GetDBConnect => db_connector_;


    private void Awake()
    {
        ConnectToDB(db_name_);
    }

    void ConnectToDB(string _db_name)
    {
        string file_path;

    //Get File Path
#if UNITY_EDITOR
        file_path = Path.Combine(Application.dataPath, "DataBase/" + _db_name).Replace("\\", "/");
#else
        file_path = Path.Combine(Application.persistentDataPath, "DataBase/" + _db_name).Replace("\\", "/");
#endif

        //URI path
        db_path_ = "URI=file:" + file_path;
        Debug.Log(db_path_);

        //Connect File
        if (!File.Exists(file_path))                                            //creat file if not exists
        {
            DataBaseCreator creator = new DataBaseCreator();
            creator.CreateDbFile(ref db_connector_, db_path_);

            if(db_connector_ != null)
            {
                Debug.Log("Created and connected to new DB");
            }
            else
            {
                Debug.Log("Connection To New DB was Failed");
            }
        }
        else
        {
            db_connector_ = new SqliteConnection(db_path_);                    //connect
            db_connector_.Open();

            if (db_connector_ != null)
            {
                Debug.Log("Connected to DataBase");
            }
            else
            {
                Debug.Log("can not Connect to DataBase");
            }
        }
    }

    public void CloseToDB()
    {
        if (db_connector_ == null) return;
        if (db_connector_.State != ConnectionState.Open) return;
        
        db_connector_.Close();
        db_connector_.Dispose();

        Debug.Log("Closed db_Connector");
    }
}
