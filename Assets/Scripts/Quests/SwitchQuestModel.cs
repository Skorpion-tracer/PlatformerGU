using PlatformerGU.Views;
using UnityEngine;

namespace PlatformerGU.Quests
{
    public class SwitchQuestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.GetComponent<CharacterView>() != null;
        }
    }
}
