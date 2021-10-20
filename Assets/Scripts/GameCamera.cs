using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform gameManager;

    GameManager gameManagerC;
    void Start()
    {
        gameManagerC = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerC.IsShowingDialog()) { return; }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
