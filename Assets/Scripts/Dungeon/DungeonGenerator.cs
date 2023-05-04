using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    public GameObject[] prefabs;
    private List<Vector2Int> dungeonRooms;
    private float room = 19.92f;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Start", 0, 0);

        foreach (Vector2Int roomLocation in rooms)
        {
            if (roomLocation == dungeonRooms[dungeonRooms.Count - 1] /*&& (roomLocation == Vector2Int.zero)*/)
            {
                RoomController.instance.LoadRoom("End", roomLocation.x, roomLocation.y);
            }
            else
            {
                RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);

                // Choose a random prefab from the array
                GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

                // Spawn the chosen prefab at the same location as the "Empty" room
                Instantiate(randomPrefab, new Vector3(-1.47f + -0.007124f, room), Quaternion.identity);
                room = room + 18f;
            }
        }
    }
}