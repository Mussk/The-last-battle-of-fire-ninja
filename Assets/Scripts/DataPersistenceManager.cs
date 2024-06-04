using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public abstract class DataPersistenceManager<T> : MonoBehaviour where T : new()
{
    [Header("File Storage Config")]
    [SerializeField]
    protected string configFileName;
    
    protected T serializedData;

    [field: SerializeReference]
    //can`t do List<IDataPersistence> besause it is not allowed in Unity (does not show in the inspector)
    public List<SerializableController<T>> dataPersistenceObjects;


    protected FileDataHandler<T> fileDataHandler;
    

    protected virtual void Awake() 
    {

        this.fileDataHandler = new FileDataHandler<T>(Application.persistentDataPath, configFileName);

    }
   
    protected virtual void Start()
    {   
       
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        LoadData();
    }


    protected void LoadData() 
    {
      
        this.serializedData = fileDataHandler.Load();

        if (this.serializedData == null)
        {
            Debug.Log("No data was found. Initializing default data.");
                
            foreach(SerializableController<T> dataPersistentObj in dataPersistenceObjects)
            {
                
                dataPersistentObj.InitDefaultData();

            }


            return;

        }

        foreach (IDataPersistence<T> dataPersistenceObj in dataPersistenceObjects)
        {

            dataPersistenceObj.LoadData(serializedData);

        }

        Debug.Log("Loaded skins");
  
    }

    protected void SaveData()
    {

        T serializedData = new();

        foreach (IDataPersistence<T> dataPersistenceObj in dataPersistenceObjects)
        {

            dataPersistenceObj.SaveData(ref serializedData);

            Debug.Log("Saved data:" + dataPersistenceObj.ToString());
                
        }

        
        fileDataHandler.Save(serializedData);

    }


    protected virtual void OnSceneUnloaded(Scene scene)
    {   
        SaveData();
        Debug.Log("Data is saved");
    }

    protected virtual void OnApplicationQuit()
    {
        SaveData();
        Debug.Log("Data is saved");
    }
}
