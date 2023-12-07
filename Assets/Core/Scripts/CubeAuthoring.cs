using Unity.Entities;
using UnityEngine;

using Scenes.Scripts.Components;

namespace Scenes.Scripts
{
    public class CubeAuthoring : MonoBehaviour
    {
        public float MovementSpeed = 10.0f;

        private class MovementAuthroingBaker : Baker<CubeAuthoring>
        {
            public override void Bake(CubeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.NonUniformScale);

                AddComponent<Cube>(entity);
                AddComponent(entity, new MovementComponent
                {
                    Speed = authoring.MovementSpeed
                });
            }
        }
    }

    public struct Cube : IComponentData
    {
    }
}