using PlatformerGU.Views;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public class BulletsEmitter
    {
        private const float _delay = 3;
        private const float _startSpeed = 7f;

        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _position;
        private Transform _aim;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletsEmitter(List<BulletView> bulletViews, Transform position, Transform aim)
        {
            _position = position;
            _aim = aim;
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
                _bullets[_currentIndex].Throw(_position.position, _aim, _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count) _currentIndex = 0;
            }
        }
    }
}
