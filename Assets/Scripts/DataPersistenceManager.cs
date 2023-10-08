using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField]
    private string ownedSkinsFile;


    private SerializedData ownedSkinData;

    
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler fileDataHandler;

    [SerializeField]
    private ShopController shopController;

    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {   
        if(Instance != null)
        {
            Debug.LogError("Found more than one DataPersistenceManager on the scene.");
        }

        Instance = this;

        SceneManager.sceneUnloaded += OnSceneUnloaded;

        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, ownedSkinsFile);
        
        dataPersistenceObjects = new List<IDataPersistence>();
        //done this way because ShopController is incactive during Awake method execution
        dataPersistenceObjects.Add(shopController);

        LoadData();
    }

    private void Start()
    {
       

    }


    public void InitDefaultData() 
    { 
    
        this.ownedSkinData = new SerializedData();
        shopController.IsDefaultPrices = true;

    }   

    public void LoadData() 
    {

        this.ownedSkinData = fileDataHandler.Load();

        if(this.ownedSkinData == null)
        {
            Debug.Log("No data was found. Initializing default data.");
            InitDefaultData();

            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(ownedSkinData);
        }

        Debug.Log("Loaded skins");
    }

    public void SaveData()
    {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref ownedSkinData);

            Debug.Log("Saved skin:" + dataPersistenceObj.ToString());
        }

        fileDataHandler.Save(ownedSkinData);
    }


    private void OnSceneUnloaded(Scene scene)
    {   
        SaveData();
        Debug.Log("Data is saved");
    }

    private void OnApplicationQuit()
    {
        SaveData();
        Debug.Log("Data is saved");
    }
}
