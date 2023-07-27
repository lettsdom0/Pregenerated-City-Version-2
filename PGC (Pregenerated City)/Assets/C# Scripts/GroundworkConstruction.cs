using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundworkConstruction : MonoBehaviour
{
    public GameObject BuildingA;
    public GameObject BuildingB;
    public GameObject BuildingC;
    public GameObject BuildingD;
    public GameObject BuildingE;
    public GameObject BuildingF;
    //gameobject lists
    List<GameObject> gatheredBlocks = new List<GameObject>();
    List<Transform> gatheredTransforms = new List<Transform>();

    // counters for lists
    private int blockCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        //grabs each of the blocks and adds them to the gathered blocks list
        foreach (GameObject gatheredBlock in GameObject.FindGameObjectsWithTag("Block A"))
        {
            gatheredBlocks.Add(gatheredBlock);
        }
        foreach (GameObject gatheredBlock in GameObject.FindGameObjectsWithTag("Block B"))
        {
            gatheredBlocks.Add(gatheredBlock);
        }
        foreach (GameObject gatheredBlock in GameObject.FindGameObjectsWithTag("Block C"))
        {
            gatheredBlocks.Add(gatheredBlock);
        }
        foreach (GameObject gatheredBlock in GameObject.FindGameObjectsWithTag("Block D"))
        {
            gatheredBlocks.Add(gatheredBlock);
        }
        foreach (GameObject gatheredBlock in GameObject.FindGameObjectsWithTag("Block E"))
        {
            gatheredBlocks.Add(gatheredBlock);
        }
        foreach (GameObject gatheredBlock in GameObject.FindGameObjectsWithTag("Block F"))
        {
            gatheredBlocks.Add(gatheredBlock);
        }
        //adds transforms to gathered Transforms
        foreach (GameObject gatheredBlock in gatheredBlocks)
        {
            gatheredTransforms.Add(gatheredBlock.GetComponent<Transform>());
        }
        blockCount = gatheredBlocks.Count;

        //spawns building prefabs based on tag of block in the list
        for (int blockNum = 0 ; blockNum < blockCount; blockNum++)
        {
            if (gatheredBlocks[blockNum].CompareTag("Block A"))
            {
                var GO = Instantiate(BuildingA);
                var spawnLocation = GO.transform.parent = gatheredTransforms[blockNum];
                GO.transform.position = new Vector3(spawnLocation.transform.position.x, (spawnLocation.transform.position.y + 3), spawnLocation.transform.position.z);
                GO.transform.rotation = spawnLocation.transform.rotation * Quaternion.Euler(0, 0, 0);
            }
            else if (gatheredBlocks[blockNum].CompareTag("Block B"))
            {
                var GO = Instantiate(BuildingB);
                var spawnLocation = GO.transform.parent = gatheredTransforms[blockNum];
                GO.transform.position = new Vector3(spawnLocation.transform.position.x, (spawnLocation.transform.position.y + 3.55f), spawnLocation.transform.position.z);
                GO.transform.rotation = spawnLocation.transform.rotation * Quaternion.Euler(0, 0, 0);
            }
            else if (gatheredBlocks[blockNum].CompareTag("Block C"))
            {
                var GO = Instantiate(BuildingC);
                var spawnLocation = GO.transform.parent = gatheredTransforms[blockNum];
                GO.transform.position = new Vector3(spawnLocation.transform.position.x, (spawnLocation.transform.position.y + 2), spawnLocation.transform.position.z);
                GO.transform.rotation = spawnLocation.transform.rotation * Quaternion.Euler(0, 0, 0);
            }
            else if (gatheredBlocks[blockNum].CompareTag("Block D"))
            {
                var GO = Instantiate(BuildingD);
                var spawnLocation = GO.transform.parent = gatheredTransforms[blockNum];
                GO.transform.position = new Vector3(spawnLocation.transform.position.x, (spawnLocation.transform.position.y + 6), spawnLocation.transform.position.z);
                GO.transform.rotation = spawnLocation.transform.rotation * Quaternion.Euler(0, 0, 0);
            }
            else if (gatheredBlocks[blockNum].CompareTag("Block E"))
            {
                var GO = Instantiate(BuildingE);
                var spawnLocation = GO.transform.parent = gatheredTransforms[blockNum];
                GO.transform.position = new Vector3(spawnLocation.transform.position.x, (spawnLocation.transform.position.y + 11), spawnLocation.transform.position.z);
                GO.transform.rotation = spawnLocation.transform.rotation * Quaternion.Euler(0, 0, 0);
            }
            else if (gatheredBlocks[blockNum].CompareTag("Block F"))
            {
                var GO = Instantiate(BuildingF);
                var spawnLocation = GO.transform.parent = gatheredTransforms[blockNum];
                GO.transform.position = new Vector3(spawnLocation.transform.position.x, (spawnLocation.transform.position.y + 6), spawnLocation.transform.position.z);
                GO.transform.rotation = spawnLocation.transform.rotation * Quaternion.Euler(0, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
