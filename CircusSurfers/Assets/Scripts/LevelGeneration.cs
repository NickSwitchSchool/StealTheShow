using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject player;
    public GameObject startNode;
    public float minimumDistanceToLastNode;
    public GameObject lastSpawnedNode;

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
            if (lastSpawnedNode.TryGetComponent<LevelNode>(out LevelNode _newLevelNode))
            {
                int _index = Random.Range(0, lastSpawnedNode.GetComponent<LevelNode>().possibleNextNodes.Length);
                Vector3 _newLevelNodePos = lastSpawnedNode.GetComponent<LevelNode>().nextNodeLocation.position;
                lastSpawnedNode = Instantiate(lastSpawnedNode.GetComponent<LevelNode>().possibleNextNodes[_index], _newLevelNodePos, Quaternion.identity);
            }
            {
                int _index = Random.Range(0, lastSpawnedNode.GetComponentInChildren<LevelNode>().possibleNextNodes.Length);
                Vector3 _newLevelNodePos = lastSpawnedNode.GetComponentInChildren<LevelNode>().nextNodeLocation.position;
                lastSpawnedNode = Instantiate(lastSpawnedNode.GetComponentInChildren<LevelNode>().possibleNextNodes[_index], _newLevelNodePos, Quaternion.identity);
            }
        }
    }
}
