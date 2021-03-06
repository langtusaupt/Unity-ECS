﻿using CommonECS.Components;
using Unity.Entities;
using Unity.Jobs;

namespace CommonECS.Systems
{
	public class ProcessDestroySystem : SystemBase
	{
		private BeginInitializationEntityCommandBufferSystem m_CommandBuffer;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();

			Entities
				.WithAll<DestroyTag>()
				.ForEach((int entityInQueryIndex, Entity entity) =>
				{
					commandBuffer.DestroyEntity(entityInQueryIndex, entity);
				})
				.ScheduleParallel();

			m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
		}
	}
}
