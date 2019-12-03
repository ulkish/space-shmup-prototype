using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For loading & reloading of scenes.
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // A singleton for Main.
    static public Main S;

    [Header("Set in Inspector")]
    // ARray of Enemy prefabs.
    public GameObject[] prefabEnemies;
    // Number of Enemies/second
    public float enemySpawnPerSecond = 0.5f;
    // Padding for position.
    public float enemyDefaultPadding = 1.5f;

    private BoundsCheck boundsCheck;

    void Awake()
    {
        S = this;
        // Set boundsCheck to reference the BoundsCheck component on this game
        // object.
        boundsCheck = GetComponent<BoundsCheck>();

        // Invoke SpawnEnemy() once (in 2 seconds, based on default values).
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        // Pick a random Enemy prefab to instantiate.
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ ndx ]);

        // Position the Enemy above the screen with a random x position.
        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        // Set the initial position for the spawned Enemy.
        Vector3 pos = Vector3.zero;
        float xMin = -boundsCheck.camWidth + enemyPadding;
        float xMax = boundsCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = boundsCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        // Invoke SpawnEnemy() again.
        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
