using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Tiny3D.Systems
{
    [AlwaysUpdateSystem]
    public class PlayerInputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var left = false;
            var right = false;
            var forward = false;
            var backward = false;

#if UNITY_DOTSPLAYER
            var Input = World.GetExistingSystem<InputSystem>();
#endif

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                forward = true;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                backward = true;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                left = true;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                right = true;

            MovementInput input = default;

            if (left && right)
                input.horizontalAxis = 0f;
            else if (left)
                input.horizontalAxis = -1f;
            else if (right)
                input.horizontalAxis = 1f;

            if (forward)
                input.verticalAxis = 1f;
            else if (backward)
                input.verticalAxis = -1f;

            Entities.ForEach((ref MovementInput inputRef) => { inputRef = input; }).Schedule();
        }
    }
}
