using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    // Start is called before the first frame update
    public int ID;
    public Sprite image;
    public int atk;
    public int def;
    public int hp;
    public abstract void Effect(BaseCharacter character,bool isEquipped);
}
