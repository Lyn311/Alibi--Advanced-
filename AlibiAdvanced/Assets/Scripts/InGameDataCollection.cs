using System;
using UnityEngine;

[Serializable]
public struct ItemInfo
{
    public string itemName;
    [TextArea(3, 10)]
    public string description;

}