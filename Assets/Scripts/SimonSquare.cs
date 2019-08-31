using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSquare : Interactable
{
    public Simon mySimon;
    public Material highLightColor, wrongColor, doneColor;
    public int myNum;
    AudioSource source;
    public AudioClip wrongSound, mySound;
    Renderer myRenderer;
    Material mycolor;
    

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        mycolor = myRenderer.material;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        myRenderer.material = highLightColor;
        source.Play();
        if(mySimon)
            mySimon.Guess(myNum, this);
    }

    IEnumerator UnHighlight()
    {
        yield return new WaitForSeconds(.5f);
        myRenderer.material = mycolor;
    }

    public void Wrong()
    {
        StartCoroutine(FlashWrong());
    }

    public void Right()
    {
        StartCoroutine(UnHighlight());
    }

    IEnumerator FlashWrong()
    {
        StopCoroutine(UnHighlight());
        
        yield return new WaitForSeconds(.5f);
        source.clip = wrongSound;
        source.Play();

        myRenderer.material = wrongColor;

        yield return new WaitForSeconds(1f);
        source.clip = mySound;
        myRenderer.material = mycolor;
    }

    public void Done()
    {
        StopCoroutine(UnHighlight());
        highLightColor = doneColor;
        myRenderer.material = doneColor;
        gameObject.tag = "Untagged";
    }
}
