using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData data = new SaveData();

    public GameManager manager;
    public Reception reception;
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
        data.totalCurrency = manager.totalSoftCurrency;

        data.receptionistLevel = reception.receptionistList[0].receptionistLevel;
        data.massageServiceLevel = massageRoom.serviceLevel;
        data.parkingServiceLevel = parking.serviceLevel;
        data.adServiceLevel = advertisement.serviceLevel;
        data.haircutServiceLevel = haircut.serviceLevel;
        data.swimServiceLevel = swimRoom.serviceLevel;
        data.photoServiceLevel = photoshoot.serviceLevel;

        data.receptionUnlocked = reception.isUnlocked;
        data.massageUnlocked = massageRoom.isUnlocked;
        data.parkingUnlocked = parking.isUnlocked;
        data.advertisementUnlocked = advertisement.isUnlocked;
        data.haircutUnlocked = haircut.isUnlocked;
        data.swimUnlocked = swimRoom.isUnlocked;
        data.photoUnlocked = photoshoot.isUnlocked;

        data.massageRoomIndex = massageRoom.workerIndex;
        data.haircutIndex = haircut.workerIndex;
        data.swimRoomIndex = swimRoom.workerIndex;
        data.photoIndex = photoshoot.workerIndex;

        data.massageSpeed = massageRoom.worker.workerSpeedLevel;
        data.haircutSpeed = haircut.worker.workerSpeedLevel;
        data.swimSpeed = swimRoom.worker.workerSpeedLevel;
        data.photoSpeed = photoshoot.worker.workerSpeedLevel;

        data.massageInterior = massageRoom.interior.currentIndex;
        data.haircutInterior = haircut.interior.currentIndex;
        data.swimInterior = swimRoom.interior.currentIndex;
        data.photoInterior = photoshoot.interior.currentIndex;

        data.massageInteriorIndex = massageRoom.interior.unlockedIndexes;
        data.haircutInteriorIndex = haircut.interior.unlockedIndexes;
        data.swimInteriorIndex = swimRoom.interior.unlockedIndexes;
        data.photoInteriorIndex = photoshoot.interior.unlockedIndexes;

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", jsonData);

    }

    public void LoadData()
    {
        string jsonData = PlayerPrefs.GetString("SaveData");
        data = JsonUtility.FromJson<SaveData>(jsonData);

        manager.totalSoftCurrency = data.totalCurrency;

        reception.receptionistList[0].receptionistLevel = data.receptionistLevel;
        massageRoom.serviceLevel = data.massageServiceLevel;
        parking.serviceLevel = data.parkingServiceLevel;
        advertisement.serviceLevel = data.adServiceLevel;
        haircut.serviceLevel = data.haircutServiceLevel;
        swimRoom.serviceLevel = data.swimServiceLevel;
        photoshoot.serviceLevel = data.photoServiceLevel;

        reception.isUnlocked = data.receptionUnlocked;
        massageRoom.isUnlocked = data.massageUnlocked;
        parking.isUnlocked = data.parkingUnlocked;
        advertisement.isUnlocked = data.advertisementUnlocked;
        haircut.isUnlocked = data.haircutUnlocked;
        swimRoom.isUnlocked = data.swimUnlocked;
        photoshoot.isUnlocked = data.photoUnlocked;

        massageRoom.workerIndex = data.massageRoomIndex;
        haircut.workerIndex = data.haircutIndex;
        swimRoom.workerIndex = data.swimRoomIndex;
        photoshoot.workerIndex = data.photoIndex;

        massageRoom.worker.workerSpeedLevel = data.massageSpeed;
        haircut.worker.workerSpeedLevel = data.haircutSpeed;
        swimRoom.worker.workerSpeedLevel = data.swimSpeed;
        photoshoot.worker.workerSpeedLevel = data.photoSpeed;

        massageRoom.interior.currentIndex = data.massageInterior;
        haircut.interior.currentIndex = data.haircutInterior;
        swimRoom.interior.currentIndex = data.swimInterior;
        photoshoot.interior.currentIndex = data.photoInterior;

        massageRoom.interior.unlockedIndexes = data.massageInteriorIndex;
        haircut.interior.unlockedIndexes = data.haircutInteriorIndex;
        swimRoom.interior.unlockedIndexes = data.swimInteriorIndex;
        photoshoot.interior.unlockedIndexes = data.photoInteriorIndex; 

    }
}

public class SaveData
{
    public float totalCurrency;

    public int receptionistLevel;
    public int massageServiceLevel;
    public int parkingServiceLevel;
    public int adServiceLevel;
    public int haircutServiceLevel;
    public int swimServiceLevel;
    public int photoServiceLevel;

    public bool receptionUnlocked;
    public bool massageUnlocked;
    public bool parkingUnlocked;
    public bool advertisementUnlocked;
    public bool haircutUnlocked;
    public bool swimUnlocked;
    public bool photoUnlocked;

    public List<int> massageRoomIndex;
    public List<int> haircutIndex;
    public List<int> swimRoomIndex;
    public List<int> photoIndex;

    public int massageSpeed;
    public int haircutSpeed;
    public int swimSpeed;
    public int photoSpeed;

    public int massageInterior;
    public int haircutInterior;
    public int swimInterior;
    public int photoInterior;

    public List<int> massageInteriorIndex;
    public List<int> haircutInteriorIndex;
    public List<int> swimInteriorIndex;
    public List<int> photoInteriorIndex; 




}
