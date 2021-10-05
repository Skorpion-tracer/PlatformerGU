using UnityEngine;

namespace PlatformerGU.Views
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Animator Animator => _animator;
    }
}

