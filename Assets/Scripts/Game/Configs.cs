using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<List<int>> Position;
}