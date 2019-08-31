using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    public List<int> sequence = new List<int>();
    public List<SimonSquare> simonSquares;
    public List<SimonSquare> playerBoard;
    public List<UnlockTrigger> lights;

    public int currGuessCount = 0; //Number of times the player has guessed this roud
    public int currSequenceNum = 0; //Current round

    bool isPlaying = false;
    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateSequence()
    {
        sequence = new List<int>();
    
        for (int i = 0; i < 6; i++)
        {
            int ran = Random.Range(0, 4);
            sequence.Add(ran);
        }

        StartCoroutine(PlaySequence());
        started = true;
    }

    public void Guess(int guessNum, SimonSquare guessSquare)
    {
        if(!started)
        {
            currSequenceNum = 0;
            currGuessCount = 0;
            guessSquare.Right();
            GenerateSequence();
        }
        else if(!isPlaying)
        {
            if(guessNum == sequence[currGuessCount])
            {
                currGuessCount--;

                if(currGuessCount < 0)
                {
                    lights[currSequenceNum].Activate();
                    currSequenceNum++;
                    currGuessCount = currSequenceNum;

                    if(currSequenceNum == sequence.Count)
                    {
                        guessSquare.Done();
                        Complete();
                    }
                    else
                    {
                        guessSquare.Right();
                        StartCoroutine(PlaySequence());
                    }
                }
                else
                {
                    guessSquare.Right();
                }
            }
            else
            {
                guessSquare.Wrong();
                foreach (var item in lights)
                {
                    item.Deactivate();
                }
                currSequenceNum = 0;
                currGuessCount = 0;
                GenerateSequence();
            }
        }
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(2f);
        isPlaying = true;
        for(int i = 0; i <= currSequenceNum; i++)
        {
            yield return new WaitForSeconds(1f);
            simonSquares[sequence[i]].Interact();
            simonSquares[sequence[i]].Right();

        }

        isPlaying = false;
    }

    void Complete()
    {
        Debug.Log("Congrats");
        foreach (var item in playerBoard)
        {
            item.Done();
        }

        foreach (var item in simonSquares)
        {
            item.Done();
        }
    }
}
