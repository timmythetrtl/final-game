using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up = 0,

    left = 1,

    down = 2,

    right = 3
};

public class DungeonCrawlerController : MonoBehaviour
{
    private static readonly Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int>
    {
        { Direction.up, Vector2Int.up},
    };

    public static List<Vector2Int> GenerateDungeon(DungeonGenerationData dungeonData)
    {
        List<Vector2Int> positionsVisited = new List<Vector2Int>();

        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();

        for (int i = 0; i < dungeonData.numberOfCrawlers; i++)
        {
            DungeonCrawler newCrawler = ScriptableObject.CreateInstance<DungeonCrawler>();
            newCrawler.Init(Vector2Int.zero);
            dungeonCrawlers.Add(newCrawler);
        }

        int iterations = Random.Range(dungeonData.iterationMin, dungeonData.iterationMax);

        for (int i = 0; i < iterations; i++)
        {
            foreach (DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                Vector2Int newPos = dungeonCrawler.Move(directionMovementMap);
                positionsVisited.Add(newPos);
            }
        }

        return positionsVisited;
    }
}
