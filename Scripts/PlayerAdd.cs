using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAdd : MonoBehaviour
{
   
    string axis = "yatay";
    public float moveSpeed = 10;
    public Rigidbody2D bombPrefab;
    public Transform bombSpawn,player1;
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
    
}
