using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{

    private const string fileName = "score";

    public static void SaveScore(Score score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GetPath(), FileMode.Create);

        ScoreData data = new ScoreData(score);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        string path = GetPath();
        
        if (!ScoreFileExists())
        {
            Debug.LogError("Score file not found in " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        ScoreData data = formatter.Deserialize(stream) as ScoreData;
        stream.Close();

        return data;
    }

    public static bool ScoreFileExists()
    {
        return File.Exists(GetPath());
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/" + fileName + ".krn";
    }
}
