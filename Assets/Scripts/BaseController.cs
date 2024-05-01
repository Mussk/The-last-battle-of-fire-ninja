using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController<T> : MonoBehaviour, IDataPersistence<T>
{
    public virtual void InitDefaultData()
    {
        Debug.Log("Hi from base class!");
    }

    public virtual void LoadData(T data)
    {
        
    }

    public virtual void SaveData(ref T dataToSave)
    {
        
    }

  
}
