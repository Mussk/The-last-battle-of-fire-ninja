using UnityEngine.SceneManagement;

public class SettingsDataPersistenceManager : DataPersistenceManager<SettingsData>
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
