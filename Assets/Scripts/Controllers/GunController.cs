using PlatformerGU.Views;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public class GunController
    {
        private GunView _gun;

        public GunController(GunView gunView)
        {
            _gun = gunView;
        }

        public void Update()
        {
            var dir = _gun.AimTransform.position - _gun.MuzzleTransform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _gun.MuzzleTransform.rotation = rotation;
        }
    }
}
