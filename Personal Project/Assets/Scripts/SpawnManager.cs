using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float[,] cornerCoords = { { 7f, 4.5f }, { 7f, -4.5f }, { -7f, 4.5f }, { -7f, -4.5f } };
    private float defY = 0.55f;
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        //Random index in coornerCoords
        int cornerCoordsIndex = Random.Range(0, 4);

        //Spawn at 1 of the 4 coordinate locations
        /*
        transform.position = new Vector3(cornerCoords[cornerCoordsIndex, 0], defY, cornerCoords[cornerCoordsIndex, 1]);
        Instantiate(enemyPrefabs[0], gameObject.transform, true);
        */
        Instantiate(enemyPrefabs[0], new Vector3(cornerCoords[cornerCoordsIndex, 0], defY, cornerCoords[cornerCoordsIndex, 1]), transform.rotation);
    }
}
