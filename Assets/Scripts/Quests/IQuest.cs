using System;
using UnityEngine;

namespace PlatformerGU.Quests
{
    public interface IQuest
    {
        event Action<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    } 
}
