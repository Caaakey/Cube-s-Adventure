using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

using Scenes.Scripts.Components;

namespace Scenes.Scripts
{
    public class CubeAuthoring : MonoBehaviour
    {
        public float DegreeperSecond = 360.0f;
        public float MovementSpeed = 10.0f;

        private class RotateAuthroingBaker : Baker<CubeAuthoring>
        {
            public override void Bake(CubeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.NonUniformScale);
                AddComponent(entity, new RotationComponent
                {
                    RadiansPerSecond = math.radians(authoring.DegreeperSecond) 
                });
                AddComponent(entity, new MovementComponent
                {
                    Speed = authoring.MovementSpeed
                });
            }
        }
    }
}