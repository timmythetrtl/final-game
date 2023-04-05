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
    // Start is called before the first frame update
    public class DungeonCrawlerController : MonoBehaviour
    {
        public static List<Vector2Int> positionsVisited = new List<Vector2Int>();

        private static readonly Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int>
        {
            { Direction.up, Vector2Int.up},
        };

        public static List<Vector2Int> GenerateDungeon(DungeonGenerationData dungeonData)
        {
            List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();
               
            for(int i = 0; i< dungeonData.numberOfCrawlers; i++)
            {
                dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
            }

            int iterations = Random.Range(dungeonData.iterationMin, dungeonData.iterationMax);

            for(int i = 0; i < iterations; i++)
            {
                foreach(DungeonCrawler dungeonCrawler in dungeonCrawlers)
                {
                    Vector2Int newPos = dungeonCrawler.Move(directionMovementMap);
                    positionsVisited.Add(newPos);
                }
            }

        return positionsVisited;

        }
    }

    
