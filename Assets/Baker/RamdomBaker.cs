using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class RamdomBaker : Baker<RamdomAuthor>
{
    public override void Bake(RamdomAuthor authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new RamdomCompoment
        {
            random = new Unity.Mathematics.Random(1)
        });
    }
}
