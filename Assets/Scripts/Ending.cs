using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject endGraphic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            endGraphic.SetActive(true);
            endGraphic.GetComponent<Animator>().SetTrigger("End");
        }
    }
}
