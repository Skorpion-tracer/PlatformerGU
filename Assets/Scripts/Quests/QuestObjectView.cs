using PlatformerGU.Views;
using System;
using UnityEngine;

namespace PlatformerGU.Quests
{
    public class QuestObjectView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;

        private Color _defaultColor;

        public int Id => _id;
        public Action<CharacterView> OnLevelObjectEnter { get; set; }

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var characterView = collision.gameObject.GetComponent<CharacterView>();
            if (characterView != null)
            {
                OnLevelObjectEnter?.Invoke(characterView);
            }
        }

        public void ProcessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }
    } 
}
