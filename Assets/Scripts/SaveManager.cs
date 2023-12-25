using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData data = new SaveData();

    public TaskManager taskManager;
    public GameManager manager;
    public Reception reception;
    public RoomManager massageRoom;
    public RoomManager parking;
    public RoomManager advertisement;
    public RoomManager haircut;
    public RoomManager swimRoom;
    public RoomManager photoshoot;
    public RoomManager pamperRoom;
    public RoomManager playroom;
    public RoomManager cafeteria;

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
        data.pamperServiceLevel = pamperRoom.serviceLevel;
        data.playServiceLevel = playroom.serviceLevel;
        data.cafeServiceLevel = cafeteria.serviceLevel;

        data.receptionUnlocked = reception.isUnlocked;
        data.massageUnlocked = massageRoom.isUnlocked;
        data.parkingUnlocked = parking.isUnlocked;
        data.advertisementUnlocked = advertisement.isUnlocked;
        data.haircutUnlocked = haircut.isUnlocked;
        data.swimUnlocked = swimRoom.isUnlocked;
        data.photoUnlocked = photoshoot.isUnlocked;
        data.pamperUnlocked = pamperRoom.isUnlocked;
        data.playUnlocked = playroom.isUnlocked;
        data.cafeUnlocked = cafeteria.isUnlocked;

        data.massageRoomIndex = massageRoom.workerIndex;
        data.haircutIndex = haircut.workerIndex;
        data.swimRoomIndex = swimRoom.workerIndex;
        data.photoIndex = photoshoot.workerIndex;
        data.pamperIndex = pamperRoom.workerIndex;
        data.playIndex = playroom.workerIndex;
        data.cafeIndex = cafeteria.workerIndex;

        data.massageSpeed = massageRoom.worker.workerSpeedLevel;
        data.haircutSpeed = haircut.worker.workerSpeedLevel;
        data.swimSpeed = swimRoom.worker.workerSpeedLevel;
        data.photoSpeed = photoshoot.worker.workerSpeedLevel;
        data.pamperSpeed = pamperRoom.worker.workerSpeedLevel;
        data.playSpeed = playroom.worker.workerSpeedLevel;
        data.cafeSpeed = cafeteria.worker.workerSpeedLevel;

        data.massageInterior = massageRoom.interior.currentIndex;
        data.haircutInterior = haircut.interior.currentIndex;
        data.swimInterior = swimRoom.interior.currentIndex;
        data.photoInterior = photoshoot.interior.currentIndex;
        data.pamperInterior = pamperRoom.interior.currentIndex;
        data.playInterior = playroom.interior.currentIndex;
        data.cafeInterior = cafeteria.interior.currentIndex;

        data.massageInteriorIndex = massageRoom.interior.unlockedIndexes;
        data.haircutInteriorIndex = haircut.interior.unlockedIndexes;
        data.swimInteriorIndex = swimRoom.interior.unlockedIndexes;
        data.photoInteriorIndex = photoshoot.interior.unlockedIndexes;
        data.pamperInteriorIndex = pamperRoom.interior.unlockedIndexes;
        data.playInteriorIndex = playroom.interior.unlockedIndexes;
        data.cafeInteriorIndex = cafeteria.interior.unlockedIndexes;



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
        pamperRoom.serviceLevel = data.pamperServiceLevel;
        playroom.serviceLevel = data.playServiceLevel;
        cafeteria.serviceLevel = data.cafeServiceLevel;

        reception.isUnlocked = data.receptionUnlocked;
        massageRoom.isUnlocked = data.massageUnlocked;
        parking.isUnlocked = data.parkingUnlocked;
        advertisement.isUnlocked = data.advertisementUnlocked;
        haircut.isUnlocked = data.haircutUnlocked;
        swimRoom.isUnlocked = data.swimUnlocked;
        photoshoot.isUnlocked = data.photoUnlocked;
        pamperRoom.isUnlocked = data.pamperUnlocked;
        playroom.isUnlocked = data.playUnlocked;
        cafeteria.isUnlocked = data.cafeUnlocked;

        massageRoom.workerIndex = data.massageRoomIndex;
        haircut.workerIndex = data.haircutIndex;
        swimRoom.workerIndex = data.swimRoomIndex;
        photoshoot.workerIndex = data.photoIndex;
        pamperRoom.workerIndex = data.pamperIndex;
        playroom.workerIndex = data.playIndex;
        cafeteria.workerIndex = data.cafeIndex;

        massageRoom.worker.workerSpeedLevel = data.massageSpeed;
        haircut.worker.workerSpeedLevel = data.haircutSpeed;
        swimRoom.worker.workerSpeedLevel = data.swimSpeed;
        photoshoot.worker.workerSpeedLevel = data.photoSpeed;
        pamperRoom.worker.workerSpeedLevel = data.pamperSpeed;
        playroom.worker.workerSpeedLevel = data.playSpeed;
        cafeteria.worker.workerSpeedLevel = data.cafeSpeed;

        massageRoom.interior.currentIndex = data.massageInterior;
        haircut.interior.currentIndex = data.haircutInterior;
        swimRoom.interior.currentIndex = data.swimInterior;
        photoshoot.interior.currentIndex = data.photoInterior;
        pamperRoom.interior.currentIndex = data.pamperInterior;
        playroom.interior.currentIndex = data.playInterior;
        cafeteria.interior.currentIndex = data.cafeInterior;

        massageRoom.interior.unlockedIndexes = data.massageInteriorIndex;
        haircut.interior.unlockedIndexes = data.haircutInteriorIndex;
        swimRoom.interior.unlockedIndexes = data.swimInteriorIndex;
        photoshoot.interior.unlockedIndexes = data.photoInteriorIndex; 
        pamperRoom.interior.unlockedIndexes = data.pamperInteriorIndex; 
        playroom.interior.unlockedIndexes = data.playInteriorIndex; 
        cafeteria.interior.unlockedIndexes = data.cafeInteriorIndex; 

        for(int i = 0; i < data.completedTask.Count; i++)
        {
            GameObject completeObject = Instantiate(CanvasManager.instance.completeTask,CanvasManager.instance.completeTaskParent);
            var complete = completeObject.GetComponent<TaskCompleted>();
            complete.taskIndex = data.completedTask[i];  
            complete.taskName = taskManager.tasks[complete.taskIndex].taskName;
            complete.rewardValue = taskManager.tasks[complete.taskIndex].rewardValue;
            completeObject.GetComponent<Button>().onClick.AddListener(() => { complete.OnClick(); });
        }
    }
}

[System.Serializable]
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
    public int pamperServiceLevel; 
    public int playServiceLevel; 
    public int cafeServiceLevel; 

    public bool receptionUnlocked;
    public bool massageUnlocked;
    public bool parkingUnlocked;
    public bool advertisementUnlocked;
    public bool haircutUnlocked;
    public bool swimUnlocked;
    public bool photoUnlocked;
    public bool pamperUnlocked;
    public bool playUnlocked;
    public bool cafeUnlocked;

    public List<int> massageRoomIndex;
    public List<int> haircutIndex;
    public List<int> swimRoomIndex;
    public List<int> photoIndex;
    public List<int> pamperIndex;
    public List<int> playIndex;
    public List<int> cafeIndex;

    public int massageSpeed;
    public int haircutSpeed;
    public int swimSpeed;
    public int photoSpeed;
    public int pamperSpeed;
    public int playSpeed;
    public int cafeSpeed;

    public int massageInterior;
    public int haircutInterior;
    public int swimInterior;
    public int photoInterior;
    public int pamperInterior;
    public int playInterior;
    public int cafeInterior;

    public List<int> massageInteriorIndex;
    public List<int> haircutInteriorIndex;
    public List<int> swimInteriorIndex;
    public List<int> photoInteriorIndex;
    public List<int> pamperInteriorIndex;
    public List<int> playInteriorIndex;
    public List<int> cafeInteriorIndex;

    public List<int> completedTask;


}
