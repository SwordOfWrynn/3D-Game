using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{

    public string achiev;

    void Start(){
    
    }
    //Save the player info out to a binary file
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Achievments.dat", FileMode.OpenOrCreate);
        AchievInfo myInfo = new AchievInfo();
        //for second achiev set myInfo.achiev2 = to the achiev, for third achiev3, and fourth is achiev4.
        myInfo.achiev1 = achiev;
        bf.Serialize(file, myInfo);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Achievments.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Achievments.dat", FileMode.Open);
            AchievInfo myLoadedInfo = (AchievInfo)bf.Deserialize(file);
            achiev = myLoadedInfo.achiev1;
        }
    }
    [System.Serializable]
    public class AchievInfo
    {
        // add a achiev for each avaliable achiev
        public string achiev1;
        public string achiev2;
        public string achiev3;
        public string achiev4;
    }
}
