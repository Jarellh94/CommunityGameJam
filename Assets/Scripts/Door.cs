using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    Animator anim;
    int numActivated = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        anim.SetTrigger("Open");
        numActivated++;
    }

    override public void DeInteract()
    {
        numActivated--;
        if(numActivated == 0)
        {
            anim.SetTrigger("Close");
        }
    }
}
