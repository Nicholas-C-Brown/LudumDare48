using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
