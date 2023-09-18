using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityQuery entityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTagCompoment));
        PlayerSpawnerCompoment playerSpawnerCompoment = SystemAPI.GetSingleton<PlayerSpawnerCompoment>();
        RamdomCompoment ramdomCompoment = SystemAPI.GetSingletonRW<RamdomCompoment>().ValueRW;
        int playerSpawnerCount = 500;
        if (entityQuery.CalculateEntityCount() <= playerSpawnerCount)
        {
            EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
            Entity spawnerEnity = commandBuffer.Instantiate(playerSpawnerCompoment.playerPrefab);
            commandBuffer.SetComponent(spawnerEnity, new MomentCompoment
            {
                speed = ramdomCompoment.random.NextFloat(10f, 20f)
            });
        }
    }
}
