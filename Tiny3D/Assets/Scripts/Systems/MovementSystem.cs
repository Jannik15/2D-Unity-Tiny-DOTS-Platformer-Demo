using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Physics;
using Unity.Tiny;
using UnityEngine;

namespace Tiny3D.Systems
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class MovementSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;

            Entities.ForEach((ref Movement Movement, ref MovementInput input, ref LocalToWorld localToWorld, ref PhysicsVelocity velocity) =>
            {
                var maxSpeed = Movement.maxSpeed;
                var targetSpeed = maxSpeed * input.verticalAxis;
                Movement.currentSpeed = math.lerp(Movement.currentSpeed, targetSpeed, deltaTime);
                var currentVelocity = localToWorld.Forward * Movement.currentSpeed * deltaTime;
                velocity.Linear = new float3(currentVelocity.x, velocity.Linear.y, currentVelocity.z);
            }).ScheduleParallel();
        }
    }
}

