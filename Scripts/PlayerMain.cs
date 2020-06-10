using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text score;
    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public Text highScore;

    public Transform ball, bomb, player1;
    string axis = "yatay";
    public float moveSpeed = 10;
    public Rigidbody2D bombPrefab;
    public Transform bombSpawn;
    public float bombSpeed = 400f;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveAx = Input.GetAxis(axis) * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAx, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(shoot());
        }
    }

    public IEnumerator shoot()
    {
        atesle();
        yield return null;

    }
    public void atesle()
    {
        var bomb = Instantiate(bombPrefab, player1.position, Quaternion.identity);
        bomb.AddForce(player1.up * bombSpeed);



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TagManager tagManager = collision.gameObject.GetComponent<TagManager>();

        if (tagManager == null) return;

        Tag tag = tagManager.myTag;

        if (tag.Equals(Tag.BOMB))
        {
            Destroy(collision.gameObject);
            addScore();
        }
    }
    private void addScore()
    {
        Score++;

        score.text = Score.ToString();

        if (Score % 5 == 0)
        {

            player1.position = new Vector2(player1.position.x, player1.position.y + 1);
        }
        if (Score > HighScore)
        {
            HighScore = Score;
            highScore.text = HighScore.ToString();
            LoadHighScore();
            ///SavedLoadManager.Save(Application.persistentDataPath + "folder"+".playerdata", new PlayerData(Score,transform.position.y));
        }


    }
    private void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("highscore");
    }
}
