using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSquare : Interactable
{
    public Simon mySimon;
    public Material highLightColor, wrongColor;
    public int myNum;
    Renderer myRenderer;
    Material mycolor;
    

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        mycolor = myRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        myRenderer.material = highLightColor;
        StartCoroutine(UnHighlight());
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

    IEnumerator FlashWrong()
    {
        yield return new WaitForSeconds(.6f);
        myRenderer.material = wrongColor;

        yield return new WaitForSeconds(1f);
        myRenderer.material = mycolor;
    }
}
