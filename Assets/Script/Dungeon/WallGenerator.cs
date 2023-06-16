using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator 
{
    public static void CreateWalls(HashSet<Vector2> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.directionList);//tổng hợp các vị trí đã được lưu khi thực hiện hàm FindWallsInDirection()
        
        foreach (var position in basicWallPositions)
        {
                tilemapVisualizer.PaintSingleBasicWall(position);//Gọi hàm PaintSingleBasicWall() bên tilemapVisualizer để vẽ vị trí tường vào map
        }
    }

    private static HashSet<Vector2> FindWallsInDirections(HashSet<Vector2> floorPositions, List<Vector2> directionList)
    {
        HashSet<Vector2> wallPositions = new HashSet<Vector2>();
        foreach (var position in floorPositions)//duyệt qua các vị trí trong floorPositions
        {
            foreach (var direction in directionList)// duyệt qua các hướng có trong vị trí của directionList
            {
                var neighbourPosition = position + direction; // khai báo biến vị trí gần kề 
                if (floorPositions.Contains(neighbourPosition) == false ) // Nếu vị trí hiện tại không có vị trí gần kề 
                    wallPositions.Add(neighbourPosition); // ==> ta sẽ thêm vị trí gần kề bị trống ấy vào danh sách wallPosition
            }
        }
        return wallPositions;
    }
}
