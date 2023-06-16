using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithms
{
    public static HashSet<Vector2> SimpleRandomWalk(Vector2 startPosition, int walkLength)//HashSet dùng để trữ các phần tử riêng biệt có thể dùng để triệt đi những phần tử bị trùng
    {
        HashSet<Vector2> path = new HashSet<Vector2>();

        path.Add(startPosition); //thêm vị trí bắt đầu vào path
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomDirection(); // vị trí mới = vị trí cũ + đi 1 ô hướng ngẫu nhiên
            path.Add(newPosition); // thêm vị trí mới vài danh sách ( giống với việc đánh dấu 1 ô trên grid )
            previousPosition = newPosition; // Giá trị cũ sẽ đổi thành giá trị mới để dùng cho lần tiếp theo
        }
        return path;
    }


    public static List<Vector2> RandomWalkCorridor(Vector2 startPosition, int corridorLength)
    {
        List<Vector2> corridor = new List<Vector2>();
        var direction = Direction2D.GetRandomDirection();
        var currentPosition = startPosition;
        corridor.Add(currentPosition);
        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }
        return corridor;
    }

}

    public static class Direction2D
    {
        public static List<Vector2> directionList = new List<Vector2>// Khởi ds chứa hướng 
        {
            new Vector2(0,(float)0.16),//Up
            new Vector2((float)0.16,0),//Right
            new Vector2(0, -(float)0.16),//Down
            new Vector2(-(float)0.16, 0)//Left
        };

        public static Vector2 GetRandomDirection()// Hàm chọn hướng ngẫu nhiên 
        {
            return directionList[Random.Range(0, directionList.Count)]; // trả vể 1 trong bốn giá trị trong danh sách
        }
    }
