using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class MovementBaker : Baker<MovementAuthor>
{
    public override void Bake(MovementAuthor authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MomentCompoment
        {
            speed = authoring.speed,
        });
        AddComponent(entity, new TagetCompoment
        {
            tagetPosition = authoring.tagetPosition,
        });
    }
}
