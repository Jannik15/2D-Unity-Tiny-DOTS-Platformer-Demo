using Unity.Entities;
using UnityEngine;

namespace Tiny3D
{
    [GenerateAuthoringComponent]
    public struct MovementInput : IComponentData
    {
        public float horizontalAxis;
        public float verticalAxis;
        public bool jump;
    }
}
