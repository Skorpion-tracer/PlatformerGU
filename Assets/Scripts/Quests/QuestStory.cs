using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlatformerGU.Quests
{
    public class QuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        public bool IsDone => _questsCollection.All(v => v.IsCompleted);

        public QuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection;
            Subscribe();
            ResetQuest(0);
        }

        private void ResetQuest(int index)
        {
            if (index < 0 || index >= _questsCollection.Count)
                return;

            var nextQuest = _questsCollection[index];

            if (nextQuest.IsCompleted)
                OnQuestCompleted(nextQuest);
            else
                _questsCollection[index].Reset();
        }

        private void Subscribe()
        {
            foreach(var quest in _questsCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }

        private void UnSubscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);

            if (IsDone)
                Debug.Log("Story done!");
            else
                ResetQuest(++index);
        }

        public void Dispose()
        {
            UnSubscribe();
        }
    }
}
