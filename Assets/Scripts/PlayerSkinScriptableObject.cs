using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkin", menuName = "ScriptableObjects/PlayerSkinScriptableObject", order = 1)]
public class PlayerSkinScriptableObject : ScriptableObject
{
    [field: SerializeField]
    public GameObject PlayerSkinModel { get; private set; }

    [field: SerializeField]
    public Material Material { get; private set; }

    [field: SerializeField]
    public int Price { get; private set; }
    
}
