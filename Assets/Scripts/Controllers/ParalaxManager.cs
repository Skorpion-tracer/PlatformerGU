using UnityEngine;

namespace PlatformerGU.Controllers
{
    public class ParalaxManager
    {
        private const float Coef = 1;

        private Vector3 _backStartPosition;
        private Vector3 _cameraStartPosition;
        private Camera _camera;
        private Transform _backTransform;

        public ParalaxManager(Camera camera, Transform backTransform)
        {
            _backStartPosition = backTransform.position;
            _cameraStartPosition = camera.transform.position;
            _camera = camera;
            _backTransform = backTransform;
        }

        public void Update()
        {
            _backTransform.position = _backStartPosition + (_camera.transform.position - _cameraStartPosition) * Coef;
        }
    }
}

