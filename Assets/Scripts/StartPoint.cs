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

        private ParalaxManager _paralaxManager;
        private MainHeroWalker _mainHeroWalker;
        private GunController _gunController;
        private BulletsEmitter _bulletsEmitter;

        private void Start()
        {
            _paralaxManager = new ParalaxManager(_camera, _background.transform);
            _mainHeroWalker = new MainHeroWalker(_characterView);
            _gunController = new GunController(_gunView);
            _bulletsEmitter = new BulletsEmitter(_bulletViews, _muzzleTransform);
        }

        private void Update()
        {
            _paralaxManager.Update();
            _mainHeroWalker.Update();
            _gunController.Update();
            _bulletsEmitter.Update();
        }

        private void FixedUpdate()
        {
            
        }

        private void OnDestroy()
        {
            
        }
    }
}
