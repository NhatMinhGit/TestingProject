using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CorridorFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator // lớp này kế thừa từ lớp SimpleRandomWalkDungeonGenerator
{
    [SerializeField]
    private int corridorLength = 14, corridorCount = 5;

    [SerializeField]
    [Range(0.1f, 1)]
    private float roomPercent = 0.8f;





    private void Start()
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();

    }

    protected override void RunProceduralGeneration()
    {
        tilemapVisualizer.Clear();
        CorridorFirstGeneration();

    }

    

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2> floorPositions = new HashSet<Vector2>(); //khai báo danh sách các vị trí của floorPositions 
        HashSet<Vector2> potentialRoomPositions = new HashSet<Vector2>();


        CreateCorridors(floorPositions, potentialRoomPositions);//gọi hàm tạo corridor

        HashSet<Vector2> roomPositions = CreateRooms(potentialRoomPositions);
        HashSet<Vector2> deadEnds = FindAllDeadEnds(floorPositions);

        CreateRoomsAtDeadEnd(deadEnds, roomPositions);

        floorPositions.UnionWith(roomPositions);


        tilemapVisualizer.PaintFloorTiles(floorPositions); // vẽ vị trí floorPositions đã gồm corridor
        
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer); //gọi hàm tạo tường để hoàn thành việc tạo 1 hành lang 
        SpawnSlime(enemy, roomPositions,Direction2D.directionList);

    }
   
    private void CreateRoomsAtDeadEnd(HashSet<Vector2> deadEnds, HashSet<Vector2> roomFloors)
    {
        foreach (var position in deadEnds)
        {
            if (roomFloors.Contains(position) == false)//!!! lưu ý
            {
                var room = RunRandomWalk(randomWalkParameters, position);
                roomFloors.UnionWith(room);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Invoke(nameof(SpawnPortal), 0.1f);
        }
    }
    public GameObject portal;

    private void SpawnPortal()
    {
        Instantiate(portal, transform.position, transform.rotation);
    }
    
    public GameObject enemy;
    public float spawnChance = 0.1f;
    private void SpawnSlime(GameObject enemy, HashSet<Vector2> floorPositions, List<Vector2> directionList)
    {
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)// duyệt qua các hướng có trong vị trí của directionList
            {
                var neighbourPosition = position + direction; // khai báo biến vị trí gần kề 
                if (floorPositions.Contains(neighbourPosition) == false) // Nếu vị trí hiện tại không có vị trí gần kề 
                {
                    float random = Random.value;
                    if (random < spawnChance)
                    {
                        Vector3 position3D = new Vector3((float)position.x - 0.08f, (float)position.y - 0.08f, 0f);
                        Instantiate(enemy, position3D, Quaternion.identity);
                    }
                }
            }
        }
        
    }
    


    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



    private HashSet<Vector2> FindAllDeadEnds(HashSet<Vector2> floorPositions)
    {
        HashSet<Vector2> deadEnds = new HashSet<Vector2>();
        foreach(var position in floorPositions)
        {
            int neighboursCount = 0;
            foreach(var direction in Direction2D.directionList)
            {
                if (floorPositions.Contains(position + direction))
                    neighboursCount++;
            }
            if (neighboursCount == 1)
                deadEnds.Add(position);
        }
        return deadEnds;
    }

    private HashSet<Vector2> CreateRooms(HashSet<Vector2> potentialRoomPositions)
    {
        HashSet<Vector2> roomPositions = new HashSet<Vector2>();
        int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent);

        List<Vector2> roomsToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList();
      
        foreach(var roomPosition in roomsToCreate)
        {
            var roomFloor = RunRandomWalk(randomWalkParameters, roomPosition);
        }
        return roomPositions;
    }
    
    private void CreateCorridors(HashSet<Vector2> floorPositions, HashSet<Vector2> potentialRoomPositions)
    {
        var currentPosition = startPosition;
        potentialRoomPositions.Add(currentPosition);

        for (int i = 0; i < corridorCount; i++)
        {
            var corridor = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, corridorLength);
            currentPosition = corridor[corridor.Count - 1];
            potentialRoomPositions.Add(currentPosition);
            floorPositions.UnionWith(corridor);
        }
    }

}
