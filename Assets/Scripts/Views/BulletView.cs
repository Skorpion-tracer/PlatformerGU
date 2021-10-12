using UnityEngine;

namespace PlatformerGU.Views
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            _spriteRenderer.enabled = visible;
        }
    }
}
