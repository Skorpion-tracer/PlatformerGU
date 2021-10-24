using System;
using UnityEngine;

namespace PlatformerGU.Views
{
    public class CharacterView : MonoBehaviour
    {
        private const string WALK_ANIMATION = "IsWalk";
        private const string JUMP_ANIMATION = "IsJump";

        [SerializeField] private Animator _animator;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public Collider2D Collider2D => _collider2D;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public void PlayWalkAnimation(bool value)
        {
            _animator.SetBool(WALK_ANIMATION, value);
        }

        public void PlayJumpAnimation(bool value)
        {
            _animator.SetBool(JUMP_ANIMATION, value);
        }
    }
}

