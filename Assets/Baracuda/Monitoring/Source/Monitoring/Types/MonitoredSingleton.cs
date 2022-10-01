// Copyright (c) 2022 Jonathan Lang

using UnityEngine;

namespace Baracuda.Monitoring.Types
{
    /// <inheritdoc />
    public abstract class MonitoredSingleton<T> : MonoSingleton<T> where T : MonoBehaviour
    {
        /// <inheritdoc />
        protected override void Awake()
        {
            base.Awake();
            MonitoringSystems.MonitoringManager.RegisterTarget(this);
        }

        /// <inheritdoc />
        protected override void OnDestroy()
        {
            base.OnDestroy();
            MonitoringSystems.MonitoringManager.UnregisterTarget(this);
        }
    }
}