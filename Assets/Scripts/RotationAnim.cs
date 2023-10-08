using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private float rotationSpeed;

    private bool mouseOver = false;

    [SerializeField]
    private GameObject playerSkinPreview;

    private Quaternion startingRotation;

    // Start is called before the first frame update
    void Awake()
    {
        startingRotation = playerSkinPreview.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver)
        {
            playerSkinPreview.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Rotation works");
        mouseOver = true;
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       mouseOver = false;
       playerSkinPreview.transform.rotation = startingRotation;
    }
}
