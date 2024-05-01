using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSkinController : BaseController<PlayerCurrentSkinData>, IDataPersistence<PlayerCurrentSkinData>
{
    [SerializeField]
    private PlayerSkinScriptableObject currentSkinScriptableObject;

    [field: SerializeField]
    private List<GameObject> PlayerModelPartsToColor { get; set; }
  

    [SerializeField]
    private Material defaultSkinMaterial;


    void Start() 
    { 
        ApplySkin(); 
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


    public override void InitDefaultData()
    {
        currentSkinScriptableObject.Material = defaultSkinMaterial;
    }

    public override void LoadData(PlayerCurrentSkinData data)
    {
        currentSkinScriptableObject.Material = GetMaterialByName(data.CurrentSkinMaterialName);
    }

    public override void SaveData(ref PlayerCurrentSkinData dataToSave)
    {

        dataToSave.CurrentSkinMaterialName = currentSkinScriptableObject.Material.name;

    }
   
    private Material GetMaterialByName(string materialName)
    {
        return Resources.Load<Material>("Material/PlayerSkinsMaterials/" + materialName);
    }

   
}
