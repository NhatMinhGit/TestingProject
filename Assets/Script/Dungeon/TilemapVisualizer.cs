using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour //Lớp dùng để vẽ tileMap
{
    [SerializeField]
    private Tilemap floorTilemap , wallTilemap; //khai báo giá trị cho Tilemap

    [SerializeField]
    private TileBase floorTile, wallTop; // khai báo giá trị cho Tilepallete mà mình muốn dùng để vẽ

    public void PaintFloorTiles(IEnumerable<Vector2> floorPositions)
    {
        PaintTiles(floorPositions,floorTilemap,floorTile);
    }
    
    private void PaintTiles(IEnumerable<Vector2> positions, Tilemap tilemap, TileBase tile)//Hàm vẽ các ô
    {
        foreach (var position in positions) // duyệt giá trị chạy qua từng ô 
        {
            PaintSingleTile(tilemap, tile, position); // vẽ từng ô
        }
    }

    internal void PaintSingleBasicWall(Vector2 position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2 position)//hàm vẽ từng ô 
    {
        var tilePosition = tilemap.WorldToCell((Vector3)position); // khai báo vị trí tile = vị trí của tile trên Tilemap
        tilemap.SetTile(tilePosition, tile);// SetTile = Vẽ tilePallete đã chọn vào ô 
    }

    public void Clear()//Hàm xóa 
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    
}
