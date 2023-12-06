using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData data = new SaveData();
    public RoomManager massageRoom;
    public RoomManager parking;
    public RoomManager advertisement;
    public RoomManager haircut;
    public RoomManager swimRoom;
    public RoomManager photoshoot;

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("SaveData"))
        {
            LoadData();
        }
    }


    public void SaveDataCall()
    {
        data.massageServiceLevel = massageRoom.serviceLevel;
        data.parkingServiceLevel = parking.serviceLevel;
        data.adServiceLevel = advertisement.serviceLevel;
        data.haircutServiceLevel = haircut.serviceLevel;
        data.swimServiceLevel = swimRoom.serviceLevel;
        data.photoServiceLevel = photoshoot.serviceLevel;

        data.massageUnlocked = massageRoom.isUnlocked;
        data.parkingUnlocked = parking.isUnlocked;
        data.advertisementUnlocked = advertisement.isUnlocked;
        data.haircutUnlocked = haircut.isUnlocked;
        data.swimUnlocked = swimRoom.isUnlocked;
        data.photoUnlocked = photoshoot.isUnlocked;

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", jsonData);

    }

    public void LoadData()
    {
        string jsonData = PlayerPrefs.GetString("SaveData");
        data = JsonUtility.FromJson<SaveData>(jsonData);

        massageRoom.serviceLevel = data.massageServiceLevel;
        parking.serviceLevel = data.parkingServiceLevel;
        advertisement.serviceLevel = data.adServiceLevel;
        haircut.serviceLevel = data.haircutServiceLevel;
        swimRoom.serviceLevel = data.swimServiceLevel;
        photoshoot.serviceLevel = data.photoServiceLevel;

        massageRoom.isUnlocked = data.massageUnlocked;
        parking.isUnlocked = data.parkingUnlocked;
        advertisement.isUnlocked = data.advertisementUnlocked;
        haircut.isUnlocked = data.haircutUnlocked;
        swimRoom.isUnlocked = data.swimUnlocked;
        photoshoot.isUnlocked = data.photoUnlocked;
        
    }
}

public class SaveData
{
    public int massageServiceLevel;
    public int parkingServiceLevel;
    public int adServiceLevel;
    public int haircutServiceLevel;
    public int swimServiceLevel;
    public int photoServiceLevel;

    public bool massageUnlocked;
    public bool parkingUnlocked;
    public bool advertisementUnlocked;
    public bool haircutUnlocked;
    public bool swimUnlocked;
    public bool photoUnlocked;

    //public List<int> massageRoomIndex;

    //public int massageInterior;




}
