using Scenes.Scripts.Components.MonoBehaviours;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Scenes.Scripts.Systems
{
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    public partial struct CameraSystem : ISystem
    {
        Entity _target;

        [BurstCompile]
        public readonly void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Cube>();
        }

        public void OnUpdate(ref SystemState state)
        {
            if (_target == Entity.Null)
            {
                var query = SystemAPI.QueryBuilder().WithAll<Cube>().Build();

                _target = query.GetSingletonEntity();
            }

            var transform = SystemAPI.GetComponent<LocalToWorld>(_target);

            MainCamera.SetPosition(transform.Position);
        }
    }
}