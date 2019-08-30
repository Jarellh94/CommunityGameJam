using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : Interactable
{
    public Transform myRoom;

    // Start is called before the first frame update
    void Start()
    {
        myRoom = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dropped()
    {
        transform.parent = myRoom;
    }
}
