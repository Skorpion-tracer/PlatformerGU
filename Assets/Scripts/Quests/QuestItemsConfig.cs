using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU.Quests
{
    [CreateAssetMenu(fileName = "QuestItemsConfig", menuName = "Config/QuestItemsConfig", order = 0)]
    public class QuestItemsConfig : ScriptableObject
    {
        [SerializeField] private int _questId;
        [SerializeField] private List<int> _questItemIdCollection;

        public int QuestId => _questId;
        public List<int> QuestItemIdCollection => _questItemIdCollection;
    } 
}
