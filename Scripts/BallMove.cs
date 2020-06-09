using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    
    public int Score { get; private set; }
    public int HighScore { get; private set; }

    public Text score;
    public Text highScore;

    public Transform ball, bomb, player1;
    public Transform top, player;

    public float hiz = 4;

    Rigidbody2D rb2;
    
    PlayerData last;

    public ParticleSystem effect;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("movement", 2);
        queryLoad();
    }

    private void queryLoad()
    {
        if (SavedLoadManager.LoadLastGame.Equals(true))
        {
            last = SavedLoadManager.Load(Application.persistentDataPath + "folder" + ".playerdata");
            Score = last.Score();
            transform.position = new Vector2(transform.position.x, last.Pos());
            score.text = Score.ToString();
            highScore.text = HighScore.ToString();
        }
        else
        {
            last = SavedLoadManager.Load(Application.persistentDataPath + "folder" + ".playerdata");
            HighScore = last.Score();
        }
    }

    // Update is called once per frame

    public void movement()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(1, 0) * hiz;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TagManager tagManager = collision.gameObject.GetComponent<TagManager>();
        

        GetComponent<AudioSource>().Play();

        if (tagManager == null) return;

        Tag tag = tagManager.myTag;
        if(tag.Equals(Tag.  DUVAR))
            GetComponent<AudioSource>().Play();

        if (tag.Equals(Tag.BOMB))
        {
            Destroy(collision.gameObject);
            addScore();
        }
        
    }
    private void addScore()
    {
        
        Score++;
        highScore.text = HighScore.ToString();
        score.text = Score.ToString();

        if (Score % 5 == 0)
            player1.position = new Vector2(player1.position.x, player1.position.y + 1);

        highScore.text = HighScore.ToString();

        if (Score > HighScore)
        {
            HighScore = Score;
            highScore.text = HighScore.ToString();
            SavedLoadManager.Save(Application.persistentDataPath + "folder"+".playerdata", new PlayerData(Score,transform.position.y));
        }
        if (ball.position.y - player.position.y < 1)
            player1.position = new Vector2(player1.position.x, player1.position.y -7);
        
    }
    private void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("highscore");
    }
    private void CreateEffect()
    {
       var vfx= Instantiate(effect, transform);
        Destroy(vfx, 1f);
    }
}
