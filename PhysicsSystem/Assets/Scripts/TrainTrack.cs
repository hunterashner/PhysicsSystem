using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTrack : MonoBehaviour
{
    public static float trackStart;
    public static float trackEnd;
    // Start is called before the first frame update
    void Start()
    {
        trackEnd = GetComponent<Collider>().bounds.size.x / 2;
        trackStart = -trackEnd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float getTrackStart()
    {
        return trackStart;
    }

    public static float getTrackEnd()
    {
        return trackEnd;
    }

    public static void setTrackStart(float newTrackStart)
    {
        trackStart = newTrackStart;
    }

    public static void setTrackEnd(float newTrackEnd)
    {
        trackEnd = newTrackEnd;
    }
}
