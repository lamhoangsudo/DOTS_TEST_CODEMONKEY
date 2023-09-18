using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
[BurstCompile]
public partial struct MovementISystem : ISystem
{
    public readonly void OnUpdate(ref SystemState state)
    {
        RefRW<RamdomCompoment> ramdomCompoment = SystemAPI.GetSingletonRW<RamdomCompoment>();
        float deltaTime = SystemAPI.Time.DeltaTime;
        JobHandle jobHandle = new MoveJob
        {
            deltaTime = deltaTime
        }.ScheduleParallel(state.Dependency);

        jobHandle.Complete();

        new CheckReachTagetPosition
        {
            ramdomCompoment = ramdomCompoment
        }.Run();
    }
}
[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    //must has one Execute method
    public readonly void Execute(MomentAspect momentAspect)
    {
        momentAspect.Move(deltaTime);
    }
}
[BurstCompile]
public partial struct CheckReachTagetPosition : IJobEntity
{
    [NativeDisableUnsafePtrRestriction] public RefRW<RamdomCompoment> ramdomCompoment;
    public readonly void Execute(MomentAspect momentAspect)
    {
        momentAspect.CheckReachTagetPosition(ramdomCompoment);
    }
}
