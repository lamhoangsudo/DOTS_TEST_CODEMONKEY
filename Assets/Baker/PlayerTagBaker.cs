using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerTagBaker : Baker<PlayerTagAuthor>
{
    public override void Bake(PlayerTagAuthor authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new PlayerTagCompoment { });
    }
}
