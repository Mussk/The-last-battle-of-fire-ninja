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

    protected override void OnEnable()
    {
        base.OnEnable();
       
    }

    protected override void OnDisable()
    {
        base.OnDisable();
       
    }


    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }

   
}
