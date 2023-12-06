using Scenes.Scripts.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.InputSystem;

namespace Scenes.Scripts.Systems
{
    public partial struct MovementSystem : ISystem
    {
        [BurstCompile]
        public readonly void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Execute.IJobEntity>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float horizontal = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);
            float vertical = (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0);

            new MovementJob()
            {
                Horizontal = horizontal,
                Vertical = vertical,
                DeltaTime = SystemAPI.Time.DeltaTime

            }.ScheduleParallel();
        }
    }


    [BurstCompile]
    partial struct MovementJob : IJobEntity
    {
        public float Horizontal;
        public float Vertical;
        public float DeltaTime;

        readonly void Execute(ref LocalTransform transform, ref PostTransformMatrix _, in MovementComponent comp)
        {
            var direction = math.normalizesafe(new float3(Horizontal, 0, Vertical));

            float3 movement = direction * comp.Speed * DeltaTime;
            transform = transform.Translate(movement);
        }
    }
}