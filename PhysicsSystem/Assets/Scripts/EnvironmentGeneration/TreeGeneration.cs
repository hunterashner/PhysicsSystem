using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGeneration : MonoBehaviour
{
    [Header("Tree Collections")]
    public GameObject[] livingTrees;
    public GameObject[] deadTrees;
    public GameObject[] allTrees;
    public GameObject[] foliage;

    private GameObject randomTree;
    private Vector3 randomLocation;
    private Quaternion placementRotation;
    private float treeHeightPlacement;

    [Header("Settings")]
    public int treeAmount;
    public int foliageAmount;
    public int mapWidth;
    public int mapDepth;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("initialzing tree placement");
        placeRandomTrees();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //place random trees at random map locations
    void placeRandomTrees()
    {
        for (int i = 0; i < treeAmount; i++)
        {
            GameObject randomTree = pickRandomTree(livingTrees);
            float groundAdjust = treeHeightCalculator(randomTree);
            Vector3 location = pickRandomLocation(
                                mapWidth,
                                groundAdjust,
                                mapDepth);
            treeSpawner(randomTree, location);
        }

        for (int i = 0; i < foliageAmount; i++)
        {
            GameObject randomTree = pickRandomTree(foliage);
            float groundAdjust = treeHeightCalculator(randomTree);
            Vector3 location = pickRandomLocation(
                                mapWidth,
                                groundAdjust,
                                mapDepth);
            treeSpawner(randomTree, location);
        }
    }

    public GameObject pickRandomTree(GameObject[] treeArray)
    {
        randomTree = treeArray[Random.Range(0, treeArray.Length)];
        randomTree.transform.localScale = new Vector3(5, 5, 5);
        //randomTree.AddComponent<Collider>();
        return randomTree;
    }

    public Vector3 pickRandomLocation(int mapWidth, float yPlacement, int mapDepth)
    {
        int randomWidth = Random.Range((mapWidth * -1) / 2, mapWidth / 2);
        Debug.Log(randomWidth);
        int randomDepth = Random.Range((mapDepth * -1) / 2, mapDepth / 2);
        Debug.Log(randomDepth);
        Vector3 randomLocation = new Vector3(randomWidth, yPlacement, randomDepth);
        return randomLocation;
    }

    public float treeHeightCalculator(GameObject tree)
    {
        float yPlacement = tree.GetComponent<MeshRenderer>().bounds.size.y;
        treeHeightPlacement = yPlacement - yPlacement;
        return treeHeightPlacement;
    }

    public void treeSpawner(GameObject tree, Vector3 placement)
    {
        Instantiate(tree, placement, Quaternion.identity);
    }
}
