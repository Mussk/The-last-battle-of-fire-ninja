using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence<T>
{
    
    void LoadData(T data);

    void SaveData(ref T dataToSave);

    void InitDefaultData();

}
