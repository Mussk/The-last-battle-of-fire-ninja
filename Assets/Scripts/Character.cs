using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public bool isMoving = true;

    void Start()
    {
        isMoving = true;
    }

}
