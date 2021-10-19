using UnityEngine;

namespace PlatformerGU.Views
{
    public class GunView : MonoBehaviour
    {
        [SerializeField] private Transform _muzzleTransform;
        [SerializeField] private Transform _aimTransform;

        public Transform MuzzleTransform => _muzzleTransform;
        public Transform AimTransform => _aimTransform;
    }
}
