using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        WatchPlayer();
    }


    private void WatchPlayer() 
    {

        transform.position = player.transform.position;

    }
}
