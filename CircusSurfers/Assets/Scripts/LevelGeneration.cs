using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject player;
    public GameObject startNode;
    public Transform startNodePos;
    public float minimumDistanceToLastNode;
    GameObject lastSpawnedNode;
    float distanceBetweenPlayerAndLastNode;

    private void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player is not assigned!");
            return;
        }
        else if (startNode == null)
        {
            Debug.LogWarning("Start node is not assigned!");
            return;
        }

        if (lastSpawnedNode == null)
        {
           lastSpawnedNode = Instantiate(startNode, startNodePos);
        }
        else if (Vector3.Distance(player.transform.position, lastSpawnedNode.transform.position) < minimumDistanceToLastNode)
        {
            int _index = Random.Range(0, lastSpawnedNode.GetComponent<LevelNode>().possibleNextNodes.Length);
        }
    }
}
