using PlatformerGU.Controllers;
using PlatformerGU.Views;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU
{
    public sealed class StartPoint : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private GunView _gunView;
        [SerializeField] private List<BulletView> _bulletViews;
        [SerializeField] private Transform _muzzleTransform;
        [SerializeField] private List<LevelObjectView> _levelObjectViews;
        [SerializeField] private LevelObjectView _deathZone;
        [SerializeField] private Transform _startPosition;

        private ParalaxManager _paralaxManager;
        private GunController _gunController;
        private BulletsEmitter _bulletsEmitter;
        private MainHeroWalkerPhysics _mainHeroWalkerPhysics;
        private List<CoinsManager> _coinsManager;
        private LevelCompleteManager _levelCompleteManager;

        private void Start()
        {
            _paralaxManager = new ParalaxManager(_camera, _background.transform);
            _gunController = new GunController(_gunView);
            _bulletsEmitter = new BulletsEmitter(_bulletViews, _muzzleTransform, _gunController.AimTransform);
            _mainHeroWalkerPhysics = new MainHeroWalkerPhysics(_characterView);            
            _coinsManager = new List<CoinsManager>();
            _levelCompleteManager = new LevelCompleteManager(_startPosition, _deathZone, _characterView);

            foreach (LevelObjectView levelObjectView in _levelObjectViews)
            {
                _coinsManager.Add(new CoinsManager(levelObjectView));
            }
        }

        private void Update()
        {
            _paralaxManager.Update();
            _gunController.Update();
            _bulletsEmitter.Update();
        }

        private void FixedUpdate()
        {
            _mainHeroWalkerPhysics.FixedUpdate();
        }

        private void OnDestroy()
        {
            
        }
    }
}
