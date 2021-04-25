using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float yOffset;

    private void Update()
    {
        float y = Mathf.Lerp(transform.position.y, target.position.y + yOffset, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

}
