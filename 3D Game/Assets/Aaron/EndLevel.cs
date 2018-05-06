using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class EndLevel : MonoBehaviour {

    public int level;

	// Use this for initialization
	public void SaveLevelPassed () {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Levels.dat", FileMode.OpenOrCreate);
        LevelsInfo myInfo = new LevelsInfo();
        if (myInfo.levels < level)
            myInfo.levels = level;
        bf.Serialize(file, myInfo);
        file.Close();
    }
	

}
[System.Serializable]
public class LevelsInfo
{
    public int levels;
}
