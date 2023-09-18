using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthor>
{
    public override void Bake(PlayerSpawnerAuthor authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new PlayerSpawnerCompoment
        {
            playerPrefab = GetEntity(authoring.player, TransformUsageFlags.Dynamic)
        });
    }
}
