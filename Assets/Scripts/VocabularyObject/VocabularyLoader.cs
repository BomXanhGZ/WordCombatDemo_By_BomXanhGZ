
using System.Collections.Generic;
using UnityEngine;
using static GameData.SettingData;


public class VocabularyLoader : MonoBehaviour
{
    public List<Vocabulary> vocabularies {private set; get;} = new List<Vocabulary>();


    public void LoadCSV(string _file_name)
    {
        //Free List
        vocabularies.Clear();

        //path
        string folder_name = "VocabularyDatas/";
        string path = folder_name + _file_name;

        //load file by resoucres.load
        TextAsset csvFile = Resources.Load<TextAsset>(path);              
        if(csvFile == null)
        {
            UnityEngine.Debug.LogError( _file_name + " File not axsits in Resoucres");
            return;
        }

        //Split line with '\n'
        string[] lines = csvFile.text.Split('\n');                          

        //ignore first line
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();          //ignore space at first and last line
            if( string.IsNullOrEmpty(line) )        //check null or empty
            { continue; }

            string[] fields = line.Split(',');
            if (fields.Length < 3)
            {
                UnityEngine.Debug.LogWarning("line " + (i + 1) + " is missing data");
            }
            else
            {
                Vocabulary vocab = new Vocabulary();
                vocab.kanji_ = fields[KANJI];
                vocab.reading_ = fields[READING];
                vocab.meaning_ = fields[MEANING];

                vocabularies.Add(vocab);
            }
        }
    }
}

