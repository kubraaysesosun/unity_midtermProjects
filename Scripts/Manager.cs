using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
   
    public void newGame(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Load(int index)
    {
     
            SavedLoadManager.LoadLastGame = true;
            SceneManager.LoadScene(index);
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Load(0);
        }
    }
    
}
