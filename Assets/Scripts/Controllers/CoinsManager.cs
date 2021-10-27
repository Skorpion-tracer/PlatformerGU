using PlatformerGU.Views;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGU.Controllers
{
    public sealed class CoinsManager : IDisposable
    {
        private LevelObjectView _coinViews;

        public CoinsManager(LevelObjectView coinViews)
        {
            _coinViews = coinViews;
            _coinViews.OnLevelObjectContact += OnLevelObjectContact;
        }

        private void OnLevelObjectContact()
        {
            GameObject.Destroy(_coinViews.gameObject);
        }

        public void Dispose()
        {
            _coinViews.OnLevelObjectContact -= OnLevelObjectContact;
            
        }

    }
}
