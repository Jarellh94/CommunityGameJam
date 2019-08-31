using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    public List<int> sequence = new List<int>();
    public List<SimonSquare> simonSquares;

    public int currGuessCount = 0; //Number of times the player has guessed this roud
    public int currSequenceNum = 0; //Current round

    bool isPlaying = false;
    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            GenerateSequence();
        }
        else if(!isPlaying)
        {
            if(guessNum == sequence[currGuessCount])
            {
                currGuessCount--;

                if(currGuessCount < 0)
                {
                    currSequenceNum++;
                    currGuessCount = currSequenceNum;

                    if(currSequenceNum == sequence.Count)
                    {
                        Complete();
                    }
                    else
                    {
                        Debug.Log("Next Level!");
                        StartCoroutine(PlaySequence());
                    }
                }
            }
            else
            {
                guessSquare.Wrong();
                currSequenceNum = 0;
                currGuessCount = 0;
                GenerateSequence();
            }
        }
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(3f);
        isPlaying = true;
        for(int i = 0; i <= currSequenceNum; i++)
        {
            simonSquares[sequence[i]].Interact();
            yield return new WaitForSeconds(1f);
        }

        isPlaying = false;
    }

    void Complete()
    {
        Debug.Log("Congrats");
    }
}
