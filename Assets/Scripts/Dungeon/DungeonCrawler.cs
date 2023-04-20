using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawler : ScriptableObject
{

    public Vector2Int Position { get; set; }

    public void Init(Vector2Int startPos)
    {
        Position = startPos;
    }

    public DungeonCrawler(Vector2Int startPos)
    {
        Position = startPos;
    }

    public Vector2Int Move(Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        Direction toMove = (Direction)Random.Range(0, directionMovementMap.Count);
        Position += directionMovementMap[toMove];
        return Position;

    }
}
