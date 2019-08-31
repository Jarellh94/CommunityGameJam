using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTrigger : Interactable
{
    public bool isActivated = false;
    public Unlock myUnlock;
    public Material deactiveMat, activeMat;

    public AudioSource mySource;

    // Start is called before the first frame update
    void Start()
    {
        mySource = GetComponent<AudioSource>();
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
        if(mySource)
            mySource.Play();
    }

    virtual public void Deactivate()
    {
        isActivated = false;
        GetComponent<Renderer>().material = deactiveMat;
        myUnlock.CheckUnlocked();
        if(mySource)
            mySource.Play();
    }
}
