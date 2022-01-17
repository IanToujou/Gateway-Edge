using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager {
    
    private static SaveManager instance;
    private int currentSave;
    private List<Save> saves = CreateEmptySaveList();

    public SaveManager() {
        for(int i = 1; i <= 3; i++) {
            if(DoesSaveExist(i)) {
                Load(i);
            } else {
                saves[i-1] = new Save();
            }
        }
        currentSave = 1;
    }

    public Save GetSave(int saveNumber) {
        if(!IsSaveLoaded(saveNumber)) Load(saveNumber);
        return saves[saveNumber-1];
    }

    public Save GetCurrentSave() {
        return GetSave(currentSave);
    }

    public void SetCurrentSave(int currentSave) {
        this.currentSave = currentSave;
    }

    public void Save(int saveNumber) {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave_" + saveNumber + ".save");
        
        bf.Serialize(file, saves[saveNumber-1]);
        
        Debug.Log("Wrote save file " + saveNumber + " to path: " + Application.persistentDataPath + "/");
        file.Close();

    }

    public void SaveCurrent() {
        Save(currentSave);
    }

    public void Load(int saveNumber) {

        if(File.Exists(Application.persistentDataPath + "/gamesave_" + saveNumber + ".save")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave_" + saveNumber + ".save", FileMode.Open);
            Save save = (Save) bf.Deserialize(file);
            saves[saveNumber-1] = save;
            file.Close();
        } else {
            CreateNewSave(saveNumber);
        }
        
    }

    public void LoadCurrent() {
        Load(currentSave);
    }

    public bool DoesSaveExist(int saveNumber) {
        
        if(saves.Count < saveNumber) return false;

        if(File.Exists(Application.persistentDataPath + "/gamesave_" + saveNumber + ".save") || saves[saveNumber-1] != null) {
            return true;
        }

        return false;

    }

    public bool IsSaveLoaded(int saveNumber) {
        return saves[saveNumber] != null;
    }

    public Save CreateNewSave(int saveNumber) {
        Save save = new Save();
        saves[saveNumber-1] = save;
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

    public void TestButton() {
        GetSave(1);
        Save(1);
    }

    private static List<Save> CreateEmptySaveList() {
        List<Save> list = new List<Save>();
        list.Add(null);
        list.Add(null);
        list.Add(null);
        return list;
    }

}
