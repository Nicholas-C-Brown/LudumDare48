using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{


    [SerializeField]
    private List<Transform> bgList;
    private List<Transform> bgInstanceList;

    [SerializeField]
    private const float xOffsetNext = 48, xOffsetPrev = -48;

    void Start()
    {
        bgInstanceList = new List<Transform>(bgList.Count * 2);
        
        foreach(Transform t in bgList)
        {
            bgInstanceList.Add(t);
            bgInstanceList.Add(InstantiateBG(t));
        }
    }

    void Update()
    {
        List<Transform> destroyList = new List<Transform>();

        foreach(Transform t in bgInstanceList)
        {
            if(t.position.x < xOffsetPrev)
            {
                destroyList.Add(t);
            } 
        }

        foreach (Transform t in destroyList)
        {
            bgInstanceList.Remove(t);
            bgInstanceList.Add(InstantiateBG(t));
            Destroy(t.gameObject);
        }
    }

    private Transform InstantiateBG(Transform bg)
    {
        return Instantiate(bg, new Vector3(xOffsetNext, bg.position.y), Quaternion.identity, transform);
    }

}
