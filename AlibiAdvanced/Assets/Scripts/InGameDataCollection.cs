using System;
using UnityEngine;

public enum ItemType { Evidence, Report }

[Serializable]
public struct ItemInfo
{
    public string itemName;
    [TextArea(3, 10)]
    public string description;

    public ItemType type;

}