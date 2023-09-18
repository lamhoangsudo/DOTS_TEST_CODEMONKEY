using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MomentAspect : IAspect
{
    private readonly RefRW<LocalTransform> localTransform;
    private readonly RefRO<MomentCompoment> momentCompoment;
    private readonly RefRW<TagetCompoment> tagetCompoment;
    public void Move(float deltaTime)
    {
        float3 direction = math.normalize(tagetCompoment.ValueRW.tagetPosition - localTransform.ValueRW.Position);
        localTransform.ValueRW.Position += direction * deltaTime * momentCompoment.ValueRO.speed;
    }
    public void CheckReachTagetPosition(RefRW<RamdomCompoment> ramdomCompoment)
    {
        float reachedTargetPosition = 0.5f;
        if (math.distance(localTransform.ValueRW.Position, tagetCompoment.ValueRW.tagetPosition) < reachedTargetPosition)
        {
            tagetCompoment.ValueRW.tagetPosition = GetRamdomTagetPosition(ramdomCompoment);
        }
    }
    private float3 GetRamdomTagetPosition(RefRW<RamdomCompoment> ramdomCompoment)
    {
        return new float3(ramdomCompoment.ValueRW.random.NextFloat(0f, 50f), 0, ramdomCompoment.ValueRW.random.NextFloat(0f, 50f));
    }
}
