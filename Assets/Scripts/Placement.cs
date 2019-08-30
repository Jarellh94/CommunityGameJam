using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    bool isActivated = false;
    public Material deactiveMat, activeMat;
    public Unlock myUnlock;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        isActivated = true;
        GetComponent<Renderer>().material = activeMat;
        myUnlock.CheckUnlocked();
    }

    void Deactivate()
    {
        isActivated = false;
        GetComponent<Renderer>().material = deactiveMat;
        myUnlock.CheckUnlocked();
    }

    public bool IsActivated()
    {
        return isActivated;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Moveable"))
        {
            Activate();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Moveable"))
        {
            Deactivate();
        }
    }
}
