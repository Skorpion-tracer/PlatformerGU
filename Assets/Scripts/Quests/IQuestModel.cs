using UnityEngine;

namespace PlatformerGU.Quests
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}
