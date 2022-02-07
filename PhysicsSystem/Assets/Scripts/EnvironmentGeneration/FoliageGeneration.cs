using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageGeneration : MonoBehaviour
{
    public GameObject[] foliage;
    private GameObject randomFoliage;
    private Vector3 randomLocation;

    public int mapWidth;
    public int mapDepth;
    // Start is called before the first frame update
    void Start()
    {
        generateFoliage(pickRandomFoliage(foliage), pickRandomLocation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject pickRandomFoliage(GameObject[] foliage)
    {
        randomFoliage = foliage[Random.Range(0, foliage.Length)];
        return randomFoliage;
    }

    public Vector3 pickRandomLocation()
    {
        return randomLocation;
    }

    public void generateFoliage(GameObject foliage, Vector3 location)
    {
        //Instantiate(foliage, location);
    }
}
