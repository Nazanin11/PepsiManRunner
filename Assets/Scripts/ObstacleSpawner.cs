using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] lanes;       // Shared lane positions
    public Transform player;        // Player reference
    public float minDistance = 4f;  // Minimum distance between obstacles
    public float maxDistance = 7f;  // Maximum distance between obstacles

    private float nextSpawnZ = 0f;  // Z position of next obstacle

    void Start()
    {
        // First obstacle appears ahead of player
        nextSpawnZ = player.position.z + maxDistance+2;
    }

    void Update()
    {
        // Spawn new obstacle when player gets close to next spawn point
        if (player.position.z + maxDistance > nextSpawnZ)
            SpawnObstacle();
    }

    void SpawnObstacle()
    {
        if (lanes.Length == 0 || obstaclePrefab == null || player == null) return;

        // Random lane selection
        int lane = Random.Range(0, lanes.Length);
        float zPos = nextSpawnZ;

        // Spawn at lane x, fixed ground height, next z position
        Vector3 spawnPos = new Vector3(lanes[lane].position.x, 0.5f, zPos);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        // Update Z position for the next obstacle
        nextSpawnZ += Random.Range(minDistance, maxDistance);
    }
}
