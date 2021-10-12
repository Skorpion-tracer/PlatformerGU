using PlatformerGU.Views;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public class BulletsEmitter
    {
        private const float _delay = 1;
        private const float _startSpeed = 5;

        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletsEmitter(List<BulletView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new BulletController(bulletView));
            }
        }

        public void Update()
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, _transform.up * _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count) _currentIndex = 0;
            }
            _bullets.ForEach(b => b.Update());
        }
    }
}
