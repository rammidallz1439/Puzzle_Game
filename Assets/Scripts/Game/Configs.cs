using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vault;

public class Configs
{
    
}

[Serializable]
public class LevelData
{
    public List<LayoutData> LevelLayoutData;
}

[Serializable]
public class LayoutData
{
    public int SpawnCount;
    public List<List<int>> Placement;
    public List<List<float>> XPositions;
    public List<ItemsData> Items;
}

[Serializable]
public class ItemsData : GameEvent
{
    public ItemTypes Item;
}