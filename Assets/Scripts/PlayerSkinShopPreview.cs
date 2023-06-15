using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinShopPreview : MonoBehaviour
{
    [field: SerializeField]
    public PlayerSkinScriptableObject PlayerSkinScriptableObject { get; private set; }

    [field: SerializeField]
    private List<GameObject> PlayerModelPartsToColor {get; set;}


    // Start is called before the first frame update
    void Awake()
    {
        ApplySkin(PlayerModelPartsToColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //get list of model parts for changing color
   

    private void ApplySkin(List<GameObject> PlayerModelPartsToColor) 
    {
    
        foreach(var playerModelPart in PlayerModelPartsToColor)
        {
            playerModelPart.GetComponent<Renderer>().material 
                = PlayerSkinScriptableObject.Material;
        }

    }
}
