using PlatformerGU.Views;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public sealed class MainHeroWalker
    {
        private const string INPUT_VERTICAL = "Vertical";
        private const string INPUT_HORIZONTAL = "Horizontal";

        private readonly float _walkSpeed = 3f;
        private readonly float _jumpStartSpeed = 8f;
        private readonly float _movingThresh = 0.1f;
        private readonly float _flyThresh = 1f;
        private readonly float _groundLevel = 0.5f;
        private readonly float _g = -10f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _yVelocity;
        private float _xAxisInput = 0;
        private bool _doJump = false;

        private CharacterView _characterView;

        public MainHeroWalker(CharacterView characterView)
        {
            _characterView = characterView;
        }

        public void Update()
        {
            _doJump = Input.GetAxis(INPUT_VERTICAL) > 0;
            _xAxisInput = Input.GetAxis(INPUT_HORIZONTAL);

            var goSideWay = Mathf.Abs(_xAxisInput) > _movingThresh;

            if (IsGrounded())
            {
                if (goSideWay) GoSideWay();
                _characterView.PlayWalkAnimation(goSideWay ? true : false);

                if (_doJump && _yVelocity == 0)
                {
                    _yVelocity = _jumpStartSpeed;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    _characterView.transform.position = _characterView.transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (goSideWay) GoSideWay();
                if (Mathf.Abs(_yVelocity) > _flyThresh)
                {
                    //_characterView.PlayJumpAnimation();
                }
                else
                {
                    //_characterView.StopJumpAnimation();
                }
                _yVelocity += _g * Time.deltaTime;
                _characterView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }

        private void GoSideWay()
        {
            _characterView.transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _characterView.transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public bool IsGrounded()
        {
            return _characterView.transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }
    }
}
