using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dataClass
{
    [System.Serializable]
    public class Data 
    {
        public string levelName;
        public string responseTime = "Not Played";
        public bool result = false;

    }

    [System.Serializable]
    public class GameInfo
    {
        
        public List<Data> Userscore = new List<Data>();

        public Data addToLevelData(string name, string time, bool value)
        {
            Data _data = new Data();
            _data.levelName = name;
            _data.responseTime = time;
            _data.result = value;
            return _data;
        }

        public Data addDefaultData(string name)
        {
            Data _data = new Data();
            _data.levelName = name;
            _data.responseTime = "Not Played";
            _data.result = false;
            return _data;
        }

    }

    [System.Serializable]
    public class SaveData
    {
        public string TotalPlayTime;
        public List<GameInfo> saveDataList = new List<GameInfo>();       

    }

}
