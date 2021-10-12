using PlatformerGU.Models;
using PlatformerGU.Views;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public class BulletController
    {
        private Bullet _bullet;
        private BulletView _bulletView;

        public BulletController(BulletView bulletView)
        {
            _bulletView = bulletView;
            _bullet = new Bullet();
        }

        public void Update()
        {
            if (IsGrounded())
            {
                SetVelocity(_bullet.Velocity.Change(y: -_bullet.Velocity.y));
                _bulletView.transform.position = _bulletView.transform.position.Change(y: _bullet.GroundLevel + _bullet.Radius);
            }
            else
            {
                SetVelocity(_bullet.Velocity + Vector3.up * _bullet.G * Time.deltaTime);
                _bulletView.transform.position += _bullet.Velocity * Time.deltaTime;
            }
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            if (_bulletView.gameObject.activeInHierarchy == false)
            {
                _bulletView = Object.Instantiate(_bulletView); 
            }
            _bulletView.transform.position = position;
            SetVelocity(velocity);
            _bulletView.SetVisible(true);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _bullet.Velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _bullet.Velocity);
            var axis = Vector3.Cross(Vector3.left, _bullet.Velocity);
            _bulletView.transform.rotation = Quaternion.AngleAxis(angle, axis);

        }

        private bool IsGrounded()
        {
            return _bulletView.transform.position.y <= _bullet.GroundLevel + _bullet.Radius + float.Epsilon && _bullet.Velocity.y <= 0;
        }
    }
}
