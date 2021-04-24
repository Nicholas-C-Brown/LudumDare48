using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float X_COORD_GEN_NEXT = 30.0f;
    private const float X_COORD_DELETE_PREV = -15.0f;

    [SerializeField] private Transform startingPart; //Starting prefab
    [SerializeField] private List<Transform> partList; //Prefab part list for generating

    private readonly List<Transform> currentParts = new List<Transform>();

    private void Awake()
    {
        //Add the first part to the list for generation.
        currentParts.Add(startingPart);
        CreatePart();
        CreatePart();
        CreatePart();
    }

    void Update()
    {
        Transform lastPart = currentParts.FirstOrDefault();
        Vector3 endPos = lastPart.Find("EndPosition").position;
        LevelPart partData = lastPart.GetComponent<LevelPart>();
        if (endPos.x <= X_COORD_GEN_NEXT && !partData.MarkedForDeletion)
        {
            CreatePart();
            partData.MarkedForDeletion = true;
        }

        if (endPos.x <= X_COORD_DELETE_PREV)
        {
            currentParts.Remove(lastPart);
            Destroy(lastPart.gameObject);
        }
    }

    private void CreatePart()
    {
        Transform randomPart = partList[Random.Range(0, partList.Count)];
        Vector3 currentPartPos = currentParts.Last().Find("EndPosition").position;
        Vector3 newPartPos = randomPart.Find("EndPosition").position;
        Transform newPart = CreateObject(randomPart, (currentPartPos + newPartPos) - new Vector3(0.1f, 0, 0));
        currentParts.Add(newPart);
    }

    private Transform CreateObject(Transform part, Vector3 position)
    {
        Transform newObjectTransform = Instantiate(part, position, Quaternion.identity);
        return newObjectTransform;
    }
}
