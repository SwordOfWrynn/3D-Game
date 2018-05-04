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
            if (myLoadedInfo.achiev1 != null)
                achiev1.text = myLoadedInfo.achiev1;
            if (myLoadedInfo.achiev2 != null)
                achiev2.text = myLoadedInfo.achiev2;
            if (myLoadedInfo.achiev3 != null)
                achiev3.text = myLoadedInfo.achiev3;
            if (myLoadedInfo.achiev4 != null)
                achiev4.text = myLoadedInfo.achiev4;
        }
    }
	
}
