using System;
using UnityEngine;

namespace PlatformerGU.Views
{
    public sealed class LevelObjectView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Transform Transform;
        public Collider2D Collider2D;
        public Rigidbody2D Rigidbody2D;

        public event Action OnLevelObjectContact;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<CharacterView>(out CharacterView view))
            {
                var character = view;
                OnLevelObjectContact?.Invoke();
            }
        }
    }
}
