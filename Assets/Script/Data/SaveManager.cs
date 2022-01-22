using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager {
    
    private static SaveManager instance;
    private Save save;

    public SaveManager() {
        if(DoesSaveExist()) {
            Load();
        } else {
            CreateNewSave();
        }
    }

    public Save GetSave() {
        return save;
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void Load() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Save save = (Save) bf.Deserialize(file);
        this.save = save;
        file.Close();
    }

    public bool DoesSaveExist() {
        return File.Exists(Application.persistentDataPath + "/gamesave.save");
    }

    public bool IsSaveLoaded() {
        return save != null;
    }

    public Save CreateNewSave() {
        save = new Save();
        return save;
    }

    public static SaveManager GetInstance() {
        if(instance == null) {
            instance = new SaveManager();
            return instance;
        } else {
            return instance;
        }
    }

}
