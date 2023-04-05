using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;

    private List<Vector2Int> dungeonRooms;

    private float room = 19.92f;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Start", 0 ,0);
        foreach(Vector2Int roomLocation in rooms)
        {
            if (roomLocation == dungeonRooms[dungeonRooms.Count - 1] /*&& (roomLocation == Vector2Int.zero)*/)
            {
                Debug.Log("Death");
                RoomController.instance.LoadRoom("End", roomLocation.x, roomLocation.y);
            }
            else
            {
                RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);

                // Get a list of all prefab files in the directory
                string prefabDirectory = @"D:\\Docs\\Unity\\Final\\Assets\\Resources\\Platforms";
                string[] prefabFiles = Directory.GetFiles(prefabDirectory, "*.prefab");

                // Choose a random prefab from the list
                string randomPrefabName = Path.GetFileNameWithoutExtension(prefabFiles[Random.Range(0, prefabFiles.Length)]);

                // Spawn the chosen prefab at the same location as the "Empty" room
                GameObject prefab = Resources.Load<GameObject>("Platforms/" + randomPrefabName);
                Instantiate(prefab, new Vector3(-1.47f + -0.007124f, room), Quaternion.identity);
                room = room + 18f;

            }
        }
    } 

}
