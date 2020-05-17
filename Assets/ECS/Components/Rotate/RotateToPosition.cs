﻿using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct RotateToPosition : IComponentData
    {
        public float3 value;
    }
}