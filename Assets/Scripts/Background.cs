using System;
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
        float timeModifier = (float)Math.Pow(2, Time.timeSinceLevelLoad / 100);
        transform.position += Vector3.left * speed * Time.deltaTime * timeModifier;
    }

}
