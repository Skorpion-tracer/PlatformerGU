using UnityEngine;

namespace PlatformerGU.Quests 
{
    [CreateAssetMenu(fileName = "QuestConfig", menuName = "Config/QuestConfig", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private QuestType _questType;

        public int Id => _id;

        public QuestType QuestType => _questType;
    }

    public enum QuestType
    {
        Switch
    }
}

