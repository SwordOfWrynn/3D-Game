using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{

    public string achiev1;
    public string achiev2;
    public string achiev3;
    public string achiev4;

    void Start(){
    
    }
    //Save the player info out to a binary file
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Achievments.dat", FileMode.OpenOrCreate);
        AchievInfo myInfo = new AchievInfo();
        //for second achiev set myInfo.achiev2 = to the achiev, for third achiev3, and fourth is achiev4.
        if(achiev1 != null)
            myInfo.achiev1 = achiev1;
        if (achiev2 != null)
            myInfo.achiev2 = achiev2;
        if (achiev3 != null)
            myInfo.achiev3 = achiev3;
        if (achiev4 != null)
            myInfo.achiev4 = achiev4;
        bf.Serialize(file, myInfo);
        file.Close();
    }
    /*public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Achievments.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Achievments.dat", FileMode.Open);
            AchievInfo myLoadedInfo = (AchievInfo)bf.Deserialize(file);
            achiev1 = myLoadedInfo.achiev1;
        }
    }*/
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
