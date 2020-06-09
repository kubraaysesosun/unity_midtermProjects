using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int score;
    public float yPosition;
    

   
    public PlayerData (int score, float pos)
    {
       
        this.score = score;
        this.yPosition = pos;
        
    }
    public int Score()
    {
        return score;
    }
    public float Pos()
    {
        return yPosition;
    }
   


}
