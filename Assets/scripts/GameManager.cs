using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int blocksleft;
   public static GameManager Instance { get; private set; }

    private void Awake()
    {
         if (Instance != null && Instance != this) 
         {
            Destroy(this);        
         }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        blocksleft = GameObject.FindGameObjectsWithTag("block").Length;
    }
    public void blockDestroyed()
    {
        blocksleft--;
        if (blocksleft <= 0) 
        {
            loadNextLevel();
        }
    }
    private void loadNextLevel()
    { 
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
