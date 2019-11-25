using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int entities = 0;
    public float[,] cornerCoords = { { 6.5f, 4f }, { 6.5f, -4f }, { -6.5f, 4f }, { -6.5f, -4f } };
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

    public int Entities
    {
        get { return entities; }
        set { entities -= value; }
    }

    void SpawnEnemy()
    {
        //Random index in coornerCoords
        int cornerCoordsIndex = Random.Range(0, 4);
        int enemyListIndex = Random.Range(0, enemyPrefabs.Length);

        //Spawn at 1 of the 4 coordinate locations
        /*
        transform.position = new Vector3(cornerCoords[cornerCoordsIndex, 0], defY, cornerCoords[cornerCoordsIndex, 1]);
        Instantiate(enemyPrefabs[0], gameObject.transform, true);
        */
        Instantiate(enemyPrefabs[enemyListIndex], new Vector3(cornerCoords[cornerCoordsIndex, 0], defY, cornerCoords[cornerCoordsIndex, 1]), transform.rotation);
        entities += 1;
    }
}
