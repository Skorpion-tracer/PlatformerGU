using Pathfinding;
using PlatformerGU.Controllers;
using PlatformerGU.GenerateLevel;
using PlatformerGU.Models;
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
        [SerializeField] private GenerateLevelView _generateLevelView;

        [Header("Protector AI")]
        [SerializeField] private EnemyTrigger _enemyTrigger;
        [SerializeField] private AIConfig _config;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private Transform[] _protectorWaypoints;

        private ParalaxManager _paralaxManager;
        private GunController _gunController;
        private BulletsEmitter _bulletsEmitter;
        private MainHeroWalkerPhysics _mainHeroWalkerPhysics;
        private List<CoinsManager> _coinsManager;
        private LevelCompleteManager _levelCompleteManager;

        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        private void Awake()
        {
            var controller = new GenerateLevelController(_generateLevelView);
            controller.Awake();
        }

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

            _protectorAI = new ProtectorAI(_characterView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
            _protectorAI.Init();

            _protectedZone = new ProtectedZone(_enemyTrigger, new List<IProtector> { _protectorAI });
            _protectedZone.Init();

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
            _levelCompleteManager?.Dispose();

            foreach (CoinsManager coin in _coinsManager)
            {
                coin.Dispose();
            }
        }
    }
}
