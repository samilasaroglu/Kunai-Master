using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool GameStart;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void StartTheGame()
    {
        StartCoroutine(StartGame());
    }


    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(.1f);

        GameStart = true;
    }
}
