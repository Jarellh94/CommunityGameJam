using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    Animator anim;

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
    }
}
