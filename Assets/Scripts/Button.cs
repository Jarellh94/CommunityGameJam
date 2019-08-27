using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        target.GetComponent<ExitDoor>().Open();
    }  
}
