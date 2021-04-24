using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPart : MonoBehaviour
{
    [SerializeField] public bool MarkedForDeletion = false;

    void Update()
    {
        float timeModifier = (float) Math.Pow(2, Time.timeSinceLevelLoad / 100);
        gameObject.transform.position += (Vector3)Globals.MOVE_SPEED * Time.deltaTime * timeModifier;
    }
}
