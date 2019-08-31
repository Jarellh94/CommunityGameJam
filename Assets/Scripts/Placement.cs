using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : UnlockTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
