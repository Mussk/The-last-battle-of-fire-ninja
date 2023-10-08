using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSkinHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerSkinScriptableObject currentSkinScriptableObject;

    [field: SerializeField]
    private List<GameObject> PlayerModelPartsToColor { get; set; }
  
    private SerializedData currentSkinData;

    private FileDataHandler fileDataHandler;

    [SerializeField]
    private Material defaultSkinMaterial;

    [SerializeField]
    private string fileName;


    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        LoadData();

        ApplySkin();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetCurrentSkin(PlayerSkinScriptableObject playerSkinScriptableObjectToSet)
    {
        currentSkinScriptableObject.Material = playerSkinScriptableObjectToSet.Material;
    }

    public void ApplySkin() 
    {
        if(currentSkinScriptableObject.Material != null)
            foreach (var modelPart in PlayerModelPartsToColor)
                modelPart.GetComponent<Renderer>().material
                = currentSkinScriptableObject.Material;

    }

    //Intializes default skin
    public void InitDefaultData()
    {

        currentSkinData = new SerializedData();
        currentSkinData.SkinData.Add(defaultSkinMaterial.name);
    }

    public void LoadData()
    {
        this.currentSkinData = fileDataHandler.Load();

        if (this.currentSkinData == null)
        {
            Debug.Log("No data was found. Initializing default data.");
            InitDefaultData();
        }
        
            currentSkinScriptableObject.Material = GetMaterialByName(currentSkinData.SkinData.First());
            
    }

    public void SaveData()
    {

        currentSkinData.SkinData.Clear();

        currentSkinData.SkinData.Add(currentSkinScriptableObject.Material.name);

        fileDataHandler.Save(currentSkinData);
    }

    private Material GetMaterialByName(string materialName)
    {
        return Resources.Load<Material>("Material/PlayerSkinsMaterials/" + materialName);
    }

    private void OnSceneUnloaded(Scene scene)
    {   
       SaveData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
        
    }
}
