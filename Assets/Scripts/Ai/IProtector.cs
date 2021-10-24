using UnityEngine;

namespace PlatformerGU.Models
{
    public interface IProtector
    {
        void StartProtection(GameObject invader);
        void FinishProtection(GameObject invader);
    }
}
