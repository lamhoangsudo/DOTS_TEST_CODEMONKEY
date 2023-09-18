using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct PlayerSpawnerCompoment : IComponentData
{
    public Entity playerPrefab;
}
