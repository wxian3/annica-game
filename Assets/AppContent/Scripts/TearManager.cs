using UnityEngine;

public class TearManager : MonoBehaviour
{
    public GameObject tear;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (tear, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
