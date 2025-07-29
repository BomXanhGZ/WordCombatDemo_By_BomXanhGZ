
using UnityEngine;

public class SyncLevelFromResource
{
    public void SyncData(GameManagerData ref_GameManagerData,
                         DataBaseQuery ref_DataBaseQuery,
                         DataBaseTemporary ref_DataBaseTemporary)
    {
        //Check DataBase
        int level_value_in_data_base = ref_DataBaseTemporary.temp_data_.Count;
        int level_value_in_resource = ref_GameManagerData.csv_files_.Length;

        //Insert more DataLevel From Resource when DB Is missing
        if(level_value_in_data_base <  level_value_in_resource)
        {
            int insert_val = level_value_in_resource - level_value_in_data_base;
            Debug.LogWarning(insert_val + " is missing!");

            for (int i = 0; i < insert_val; i++)
            {
                ref_DataBaseQuery.InsertData(ref_DataBaseTemporary.current_table_name_);
            }

            Debug.LogWarning("Creating " + insert_val + " Was Successful");
        }
    }
}
