using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UIElements;

public partial class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        //run on main thread
        //range only run on main thread
        /*Entities.ForEach((ref LocalTransform localTransform, ref MomentCompoment compoment) =>
        {
            localTransform.Position += new float3(UnityEngine.Random.Range(-1f, 1f) * SystemAPI.Time.DeltaTime * compoment.speed, 0, UnityEngine.Random.Range(-1f, 1f) * SystemAPI.Time.DeltaTime * compoment.speed);
        }).Run();*/
        //run all free thread
        /*Entities.ForEach((ref LocalTransform localTransform, ref MomentCompoment compoment) =>
        {
            localTransform.Position += new float3(UnityEngine.Random.Range(-1f, 1f) * SystemAPI.Time.DeltaTime * compoment.speed, 0, UnityEngine.Random.Range(-1f, 1f) * SystemAPI.Time.DeltaTime * compoment.speed);
        }).ScheduleParallel();*/
        //run one free thread

        /*RefRW<RamdomCompoment> ramdomCompoment = SystemAPI.GetSingletonRW<RamdomCompoment>();
        Entities.ForEach((MomentAspect momentAspect) =>
        {
            momentAspect.Move(SystemAPI.Time.DeltaTime);
            momentAspect.CheckReachTagetPosition(ramdomCompoment);
        }).Run();*/
    }
}
