using PlatformerGU.Views;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public sealed class LevelCompleteManager : IDisposable
    {
        private Vector3 _startPosition;
        private CharacterView _characterView;
        private LevelObjectView _levelObjectView;

        public LevelCompleteManager(Transform startPosition, LevelObjectView levelObjectView, CharacterView characterView)
        {
            _startPosition = startPosition.position;

            _levelObjectView = levelObjectView;
            _levelObjectView.OnLevelObjectContact += OnLevelObjectContact;

            _characterView = characterView;            
        }

        private void OnLevelObjectContact()
        {
            _characterView.transform.position = _startPosition;
        }

        public void Dispose()
        {
            _levelObjectView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
