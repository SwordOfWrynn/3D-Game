using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Achievments : MonoBehaviour {

    public Text achiev1;
    public Text achiev2;
    public Text achiev3;
    public Text achiev4;

	// Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/Achievments.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Achievments.dat", FileMode.Open);
            SaveLoad.AchievInfo myLoadedInfo = (SaveLoad.AchievInfo)bf.Deserialize(file);
            achiev1.text = myLoadedInfo.achiev1;
            achiev2.text = myLoadedInfo.achiev2;
            achiev3.text = myLoadedInfo.achiev3;
            achiev4.text = myLoadedInfo.achiev4;
        }
    }
	
}
