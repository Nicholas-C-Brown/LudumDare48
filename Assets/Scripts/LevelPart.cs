using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPart : MonoBehaviour
{
    [SerializeField] public bool MarkedForDeletion = false;

    void Update()
    {
        gameObject.transform.position += Globals.MOVE_SPEED * Time.deltaTime;
    }
}
