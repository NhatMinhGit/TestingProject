using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();
    
    List<Loot> GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        Debug.Log(randomNumber);
        List<Loot> dropItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                dropItems.Add(item);
                return dropItems;
            }
        }
        return dropItems;
    }

    public void SpawnLoot(Vector3 spawnPosition)
    {
        List<Loot> dropItems = GetDroppedItem();
        foreach(Loot item in dropItems)
        {
            GameObject lootItem = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootItem.GetComponent<SpriteRenderer>().sprite = item.lootSprite;

            float dropForce = 200f;
            
            Vector2 dropDirection = new Vector2(Random.Range(-0.16f, 0.16f), Random.Range(-0.16f, 0.16f));
            lootItem.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce , ForceMode2D.Impulse);
        }
    }

    
}
