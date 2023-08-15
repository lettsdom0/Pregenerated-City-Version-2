using System.Collections.Generic;
using UnityEngine;

public class GroundworkConstruction : MonoBehaviour
{

    /// <summary>
    /// The Unsorted Dictionary of blocks and buildings to filter through.
    /// </summary>
    [SerializeField] internal List<BuildingVariables> blocksAndBuildings;
    SortedList<string, GameObject> gatheredBlocks = new();
    SortedList<string, GameObject> gatheredBuildings = new();
    SortedList<string,Transform> gatheredTransforms = new();

    // counters for lists
    private int buildingCount = 0;
    private int blockCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        
        //grabs each of the blocks and adds them to the gathered blocks list
        SortBlocksAndBuildings();
        gatheredTransforms =  GetTransforms();
        foreach(string blockKey in gatheredBlocks.Keys)
        {
            GameObject block = gatheredBlocks[blockKey];
            BuildingVariables blockBuildVar = block.GetComponent<BuildingVariables>();
            switch (blockBuildVar.buildingTags.blockLocation)
            {
                case BuildingTags.BuildingType.A:
                    break;
                case BuildingTags.BuildingType.B:
                    break;
                case BuildingTags.BuildingType.C:
                    break;
                case BuildingTags.BuildingType.D:
                    break;
                case BuildingTags.BuildingType.E:
                    break;
                case BuildingTags.BuildingType.F:
                    break;
            }
             /*
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
            */
        }
    }
    internal void BuildTheBuildings(BuildingVariables blockVars, string currentBlockKey)
    {
        int BuildingLimit = blockVars.spawnLimit;
        if (BuildingLimit > 0)
            return;
        foreach (GameObject Building in gatheredBuildings.Values)
        {
            BuildingVariables buildingVar = Building.GetComponent<BuildingVariables>();
            bool matching = blockVars.buildingTags.blockLocation == buildingVar.buildingTags.blockLocation;
            switch (matching)
            {
                case true:
                    var GO = Instantiate(Building);
                    var blockTransformKey = $"{currentBlockKey} transform";
                    var spawnLocation = GO.transform.parent = gatheredTransforms[blockTransformKey];
                    GO.transform.position = new Vector3(spawnLocation.transform.position.x, (spawnLocation.transform.position.y + 3), spawnLocation.transform.position.z);
                    GO.transform.rotation = spawnLocation.transform.rotation * Quaternion.Euler(0, 0, 0);
                    blockVars.spawnLimit++;
                    break;
                case false:
                    break;
            }
        }

    }
    /// <summary>
    /// <para>Sorts through the blocks and buildings to build their respective lists</para>
    /// </summary>
    internal void SortBlocksAndBuildings()
    {
        foreach (BuildingVariables variable in blocksAndBuildings)
        {
            switch (variable.BOB)
            {
                case BuildingVariables.BlockOrBuilding.Block:
                    gatheredBlocks.Add($"Block {blockCount + 1}", variable.gameObject);
                    blockCount++;
                    break;
                case BuildingVariables.BlockOrBuilding.Building:
                    gatheredBuildings.Add($"Building {buildingCount + 1}", variable.gameObject);
                    buildingCount++;
                    break;

            }
        }
    }
    internal SortedList<string,Transform> GetTransforms()
    {
        SortedList<string, Transform> transforms = new();
        foreach (string blockKey in gatheredBlocks.Keys)
        {
            GameObject block = gatheredBlocks[blockKey];
            transforms.Add($"{blockKey} Transform",block.transform);
        }
        return transforms;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
