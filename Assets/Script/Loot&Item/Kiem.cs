using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item")]
public class Kiem : ItemBase
{
    public override void Effect(BaseCharacter character, bool isEquipped)
    {
        if (isEquipped)
            character.dmg += 10;
        else
            character.dmg -= 10;
    }

}

