using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SerializableController<T> : MonoBehaviour, IDataPersistence<T>
{
    public virtual void InitDefaultData()
    {
        
    }

    public virtual void LoadData(T data)
    {
        
    }

    public virtual void SaveData(ref T dataToSave)
    {
        
    }

  
}
