using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinsDataPersistenceManager : DataPersistenceManager<SkinData>
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }


    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }

    protected override void OnSceneUnloaded(Scene scene)
    {
        base.OnSceneUnloaded(scene);
    }

}
