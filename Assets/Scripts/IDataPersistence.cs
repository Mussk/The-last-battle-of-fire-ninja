using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{

    void LoadData(SerializedData data);

    void SaveData(ref SerializedData data);
}
