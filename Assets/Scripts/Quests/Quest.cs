using PlatformerGU.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU.Quests
{
    public class Quest : IQuest
    {
        private readonly QuestObjectView _view;
        private readonly IQuestModel _model;

        public bool IsCompleted { get; private set; }

        public event Action<IQuest> Completed;

        private bool _active;

        public Quest(QuestObjectView questObjectView, IQuestModel questModel)
        {
            _view = questObjectView;
            _model = questModel;
        }

        private void OnContact(CharacterView characterView)
        {
            var completed = _model.TryComplete(characterView.gameObject);

            if (completed)
            {
                Complete();
            }
        }

        private void Complete()
        {
            if (!_active)
            {
                return;
            }

            _active = false;
            IsCompleted = true;
            _view.OnLevelObjectEnter -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this);
        }

        public void Reset()
        {
            if (_active)
            {
                return;
            }

            _active = true;
            IsCompleted = false;
            _view.OnLevelObjectEnter += OnContact;
            _view.ProcessActivate();
        }

        public void Dispose()
        {
            _view.OnLevelObjectEnter -= OnContact;
        }
    }
}
