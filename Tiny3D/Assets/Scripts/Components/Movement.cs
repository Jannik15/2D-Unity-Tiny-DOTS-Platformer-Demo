using Unity.Entities;

namespace Tiny3D
{
    [GenerateAuthoringComponent]
    public struct Movement : IComponentData
    {
        public float currentSpeed;
        public float maxSpeed;
        public bool isGrounded;
    }
}
