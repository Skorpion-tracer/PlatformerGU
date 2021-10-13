using PlatformerGU.Models;
using PlatformerGU.Views;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public class BulletController
    {
        private BulletView _bulletView;

        public BulletController(BulletView bulletView)
        {
            _bulletView = bulletView;
        }

        public void Throw(Vector3 position, Transform aim, float speed)
        {
            if (_bulletView.gameObject.activeInHierarchy == false)
                _bulletView = Object.Instantiate(_bulletView);

            _bulletView.SetVisible(false);
            _bulletView.transform.position = position;
            _bulletView.transform.rotation = RotationToAim(aim);
            _bulletView.Rigidbody2D.velocity = Vector2.zero;
            _bulletView.Rigidbody2D.angularVelocity = 0;
            _bulletView.Rigidbody2D.AddForce(_bulletView.transform.up * speed, ForceMode2D.Impulse);
            _bulletView.SetVisible(true);
        }

        private Quaternion RotationToAim(Transform aim)
        {
            var dir = _bulletView.transform.position - aim.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            return rotation;
        }
    }
}
