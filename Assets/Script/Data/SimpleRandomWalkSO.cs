using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SimpleRandomWalkParameters_",menuName = "PCG/SimpleRandomWalkData")]
public class SimpleRandomWalkSO : ScriptableObject //hàm này dùng để lưu thông sô để tạo map
{
    public int iterations = 10, walkLength = 10;
    public bool startRandomlyEachIteration = true;
}
