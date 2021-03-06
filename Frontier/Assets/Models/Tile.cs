﻿using UnityEngine;
using System.Collections;
using System;

public class Tile
{
    public enum TileType { Empty, Floor}

    Action<Tile> callbackTileTypeChanged;

    TileType type = TileType.Empty;
    public TileType Type
    {
        get
        {
            return type;
        }
        set
        {
            TileType oldType = type;
            type = value;
            // Call the callback and let things know that TileType has changed
            if (callbackTileTypeChanged != null && oldType != type)
            {
                callbackTileTypeChanged(this);
            }
        }
    }

    LooseObject looseObject;
    InstalledObject installedObject;

    World world;
    int x;
    public int X
    {
        get
        {
            return x;
        }
    }
    int y;
    public int Y
    {
        get
        {
            return y;
        }
    }

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    public void RegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        callbackTileTypeChanged += callback;
    }

    public void UnregisterTileTypeChangedCallback(Action<Tile> callback)
    {
        callbackTileTypeChanged -= callback;
    }
}
