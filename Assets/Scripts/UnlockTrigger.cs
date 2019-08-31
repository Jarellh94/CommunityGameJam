using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTrigger : Interactable
{
    public bool isActivated = false;
    public Unlock myUnlock;
    public Material deactiveMat, activeMat;

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
        if(!isActivated)
            Activate();
        else
        {
            Deactivate();
        }
    }

    public bool IsActivated()
    {
        return isActivated;
    }

    virtual public void Activate()
    {
        isActivated = true;
        GetComponent<Renderer>().material = activeMat;
        myUnlock.CheckUnlocked();
    }

    virtual public void Deactivate()
    {
        isActivated = false;
        GetComponent<Renderer>().material = deactiveMat;
        myUnlock.CheckUnlocked();
    }
}
