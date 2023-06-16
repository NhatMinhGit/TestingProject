using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;

    

    private void Start()
    {
        //GenerateDungeon();
        //RunProceduralGeneration();
    }


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2> floorPositions = RunRandomWalk(randomWalkParameters,startPosition); // tạo ds để chứa các phần tử floor và điểm bắt đầu
        tilemapVisualizer.Clear();//Xóa để map cũ sau mỗi lần tạo map mới
        tilemapVisualizer.PaintFloorTiles(floorPositions);//Tô các vị trí của floorPositions
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2 position) // 
    {
        var currentPosition = position; // lấy vị trí hiện tại để làm position
        HashSet<Vector2> floorPositions = new HashSet<Vector2>();  // đưa các giá trị vào floorPositions 
        for(int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);// Khai báo biến path dùng để tạo ngẫu nhiên giá trị của số floor tương ứng với giá walkLength 
            
            floorPositions.UnionWith(path);// Sử dụng UnionWith để thêm giá trị của path vào floorPositions
            
            
            if (parameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));// lấy một phần tử ngẫu nhiên trong danh sách để bắt đầu cho một lần lặp mới
        }
        return floorPositions;// trả về giá trị và lưu vào floorPositions
    }
}
