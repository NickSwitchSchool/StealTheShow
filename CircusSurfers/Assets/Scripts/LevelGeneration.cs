using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject player;
    public GameObject startNode;
    public float minimumDistanceToLastNode;
    GameObject lastSpawnedNode;

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
        else if (lastSpawnedNode == null)
        {
            lastSpawnedNode = startNode;
        }

        if (Vector3.Distance(player.transform.position, lastSpawnedNode.transform.position) < minimumDistanceToLastNode)
        {
            int _index = Random.Range(0, lastSpawnedNode.GetComponent<LevelNode>().possibleNextNodes.Length - 1);
            lastSpawnedNode = Instantiate(lastSpawnedNode.GetComponent<LevelNode>().possibleNextNodes[_index], lastSpawnedNode.GetComponent<LevelNode>().nextNodeLocation);
        }
    }
}
