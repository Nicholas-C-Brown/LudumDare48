using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private GameController contoller;

    [SerializeField]
    private float speed;

    private void Start()
    {
        contoller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        contoller.GameOverAction += () => speed = 0;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
