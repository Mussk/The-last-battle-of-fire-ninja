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

    //private static DataPersistenceManager<T> _instance;

    protected virtual void Awake() 
    {
        
       
        this.fileDataHandler = new FileDataHandler<T>(Application.persistentDataPath, configFileName);

       
    }
   
    protected virtual void Start()
    {

        LoadData();
    }

    protected virtual void OnEnable()
    {
        
    }

    protected virtual void OnDisable()
    {
        SaveData();
        
    }

    protected void LoadData() 
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            this.serializedData = fileDataHandler.LoadToWebGL();
        #else
            this.serializedData = fileDataHandler.Load();
        #endif
        

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

        Debug.Log("Loaded: " + typeof(T));
  
    }

    protected void SaveData()
    {

        T serializedData = new();

        foreach (IDataPersistence<T> dataPersistenceObj in dataPersistenceObjects)
        {

            dataPersistenceObj.SaveData(ref serializedData);

                  
        }

       

        #if UNITY_WEBGL && !UNITY_EDITOR
            fileDataHandler.SaveToWebGL(serializedData);
        #else   
            fileDataHandler.Save(serializedData);
        #endif

        Debug.Log("Saved: " + typeof(T));
    }

       


    protected virtual void OnApplicationQuit()
    {
        SaveData();
        
    }
}
