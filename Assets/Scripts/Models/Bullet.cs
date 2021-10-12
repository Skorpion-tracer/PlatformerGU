using UnityEngine;

namespace PlatformerGU.Models
{
    public class Bullet
    {
        private float _radius = 0.3f;
        private Vector3 _velocity;

        private float _groundLevel = 0;
        private float _g = -10;

        public float Radius => _radius;
        public Vector3 Velocity 
        {
            get => _velocity;
            set => _velocity = value;
        }

        public float GroundLevel => _groundLevel;
        public float G => _g;
    }
}
