using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceUI : MonoBehaviour
{
    [SerializeField]
    protected GameObject uiObject;

    protected Camera _camera;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    protected virtual void LateUpdate()
    {   
        //rotate UI to camera direction
        transform.rotation = _camera.transform.rotation;
    }

    
}
