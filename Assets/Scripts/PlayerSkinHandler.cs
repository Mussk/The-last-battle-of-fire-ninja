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
  
    private SkinData currentSkinData;

    private FileDataHandler<SkinData> fileDataHandler;

    [SerializeField]
    private Material defaultSkinMaterial;

    [SerializeField]
    private string fileName;


    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        this.fileDataHandler = new FileDataHandler<SkinData>(Application.persistentDataPath, fileName);

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
    public void InitDefaultSkinData()
    {

        currentSkinData = new SkinData();
        currentSkinData.CurrentSkinMaterialName = defaultSkinMaterial.name;
    }

    private void LoadData()
    {
        this.currentSkinData = fileDataHandler.Load();

        if (this.currentSkinData == null)
        {
            Debug.Log("No data was found. Initializing default data.");
            InitDefaultSkinData();
        }
        
            currentSkinScriptableObject.Material = GetMaterialByName(currentSkinData.CurrentSkinMaterialName);
            
    }

    public void SaveData()
    {

        currentSkinData.OwnedSkinsData.Clear();

        currentSkinData.OwnedSkinsData.Add(currentSkinScriptableObject.Material.name);

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
