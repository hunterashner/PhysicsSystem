using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFoliage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tree" || collision.gameObject.tag == "Foliage")
        {
            Debug.Log("collision detected");
            Destroy(collision.gameObject);
        }
    }
}
