using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavedLoadManager : MonoBehaviour
{
    public static bool LoadLastGame;
    public static void Save(string path, PlayerData playerData)
    {
        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            var formatter = new BinaryFormatter(); 
            formatter.Serialize(fs, playerData);
        }
    }
    public static PlayerData Load(string path)
    {
        using (var fs = new FileStream(path, FileMode.Open))
        {
            var formatter = new BinaryFormatter(); 
            return (PlayerData)formatter.Deserialize(fs);
        }
    }
}
