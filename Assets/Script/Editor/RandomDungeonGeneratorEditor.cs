using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(AbstractDungeonGenerator), true)]//Cho phép chỉnh sửa cho các lớp

public class RandomDungeonGeneratorEditor : Editor
{
    AbstractDungeonGenerator generator;

    private void Awake()
    {
        generator = (AbstractDungeonGenerator)target;
    }

    public override void OnInspectorGUI()//Tạo nút cho inspector
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create dungeon"))
        {
            generator.GenerateDungeon();
        }
    }

}
