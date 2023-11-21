using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] blockPrefabs;

    public float zSpawn = 0;

    public float blockLength = 30;

    public int numberOfBlocks = 5;

    private List<GameObject> activeBlocks = new List<GameObject>();

    public Transform playerTransform;

    void Start()
    {

        for (int i = 0; i < numberOfBlocks; i++)
        {
            if (i == 0) SpawnBlock(0);
            else SpawnBlock(Random.Range(0, blockPrefabs.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfBlocks * blockLength))
        {
            SpawnBlock(Random.Range(0, blockPrefabs.Length));
            DeleteBlock();
        }
    }

    public void SpawnBlock(int blockIndex)
    {
        GameObject newBlock = Instantiate(blockPrefabs[blockIndex], transform.forward * zSpawn, transform.rotation);
        activeBlocks.Add(newBlock);
        zSpawn += blockLength;
    }

    public void DeleteBlock()
    {
        Destroy(activeBlocks[0]);
        activeBlocks.RemoveAt(0);
    }
}
