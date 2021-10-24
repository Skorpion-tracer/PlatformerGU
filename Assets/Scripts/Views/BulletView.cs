using UnityEngine;

namespace PlatformerGU.Views
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            _spriteRenderer.enabled = visible;
        }
    }
}
