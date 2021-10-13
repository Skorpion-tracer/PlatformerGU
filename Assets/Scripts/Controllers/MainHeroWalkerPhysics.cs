using PlatformerGU.Views;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public sealed class MainHeroWalkerPhysics
    {
        private const string INPUT_VERTICAL = "Vertical";
        private const string INPUT_HORIZONTAL = "Horizontal";

        private readonly float _walkSpeed = 150f;
        private readonly float _jumpForce = 350f;
        private readonly float _jumpTresh = 0.1f;
        private readonly float _movingThresh = 0.1f;

        private bool _doJump = false;
        private float _goSideWay = 0;

        private readonly CharacterView _characterView;
        private readonly ContactsPoller _contactsPoller;

        public MainHeroWalkerPhysics(CharacterView characterView)
        {
            _characterView = characterView;
            _contactsPoller = new ContactsPoller(_characterView.Collider2D);
        }

        public void FixedUpdate()
        {
            _doJump = Input.GetAxis(INPUT_VERTICAL) > 0;
            _goSideWay = Input.GetAxis(INPUT_HORIZONTAL);
            _contactsPoller.Update();

            var walks = Mathf.Abs(_goSideWay) > _movingThresh;

            if (walks) _characterView.SpriteRenderer.flipX = _goSideWay < 0;
            var newVelocity = 0f;
            
            if (walks &&
                (_goSideWay > 0 || !_contactsPoller.HasLeftContacts) &&
                (_goSideWay < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = Time.fixedDeltaTime * _walkSpeed *
                    (_goSideWay < 0 ? -1 : 1);
            }

            _characterView.Rigidbody2D.velocity = _characterView.Rigidbody2D.velocity.Change(x: newVelocity);

            if (_contactsPoller.IsGrounded && _doJump &&
                Mathf.Abs(_characterView.Rigidbody2D.velocity.y) <= _jumpTresh)
            {
                _characterView.Rigidbody2D.AddForce(Vector3.up * _jumpForce);
                _characterView.PlayWalkAnimation(false);
                _characterView.PlayJumpAnimation(_doJump);
            }            

            if (_contactsPoller.IsGrounded && !walks)
            {
                _characterView.PlayWalkAnimation(false);
                _characterView.PlayJumpAnimation(_doJump);
            }
            else if(_contactsPoller.IsGrounded && walks)
            {
                _characterView.PlayWalkAnimation(true);
                _characterView.PlayJumpAnimation(_doJump);
            }
        }
    }
}
