using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Config/";
    public static void Init()
    {
        // Test if Save Folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
    public static void SaveConfig(Rulesets config,string nb) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (nb == "")
        {
            string path = Application.dataPath + "/Config/DefaultConfig.cfg";
            FileStream stream = new FileStream(path, FileMode.Create);
            DataConfig data = new DataConfig(config);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else
        {
            string path = Application.dataPath + "/Config/Config" + nb + ".cfg";
            FileStream stream = new FileStream(path, FileMode.Create);
            DataConfig data = new DataConfig(config);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        
    }
 
    public static DataConfig loadConfig (string nb)
    {

        
        if (nb == "")
        {
            string path = Application.dataPath + "/Config/DefaultConfig.cfg";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                DataConfig data = formatter.Deserialize(stream) as DataConfig;

                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Config file not found in " + path);
                return null;
            }
        }
        else
        {
            string path = Application.dataPath + "/Config/Config" + nb + ".cfg";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                DataConfig data = formatter.Deserialize(stream) as DataConfig;

                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Config file not found in " + path);
                return null;
            }

        }

        
    }

}
