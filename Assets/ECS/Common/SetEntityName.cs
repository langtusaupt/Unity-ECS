﻿using Unity.Entities;
using UnityEngine;

namespace Common.ECS
{
    public class SetEntityName : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
#if UNITY_EDITOR
            dstManager.SetName(entity, this.name);
#endif
        }
    }
}