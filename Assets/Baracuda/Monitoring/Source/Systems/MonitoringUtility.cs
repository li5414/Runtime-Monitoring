﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Baracuda.Monitoring.API;
using Baracuda.Pooling.Concretions;
using JetBrains.Annotations;
using UnityEngine;

namespace Baracuda.Monitoring.Source.Systems
{
    internal class MonitoringUtility : IMonitoringUtility, IMonitoringUtilityInternal
    {
        private IMonitoringManager _monitoringManager;

        internal MonitoringUtility(IMonitoringManager monitoringManager)
        {
            _monitoringManager = monitoringManager;
        }
        
        //--------------------------------------------------------------------------------------------------------------

        private readonly HashSet<int> _fontHashSet = new HashSet<int>();
        
        public bool IsFontHashUsed(int fontHash)
        {
            return _fontHashSet.Contains(fontHash);
        }
        
        public void AddFontHash(int fontHash)
        {
            _fontHashSet.Add(fontHash);
        }

        //--------------------------------------------------------------------------------------------------------------
        
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IMonitorUnit[] GetMonitorUnitsForTarget(object target)
        {
            if (!_monitoringManager.IsInitialized)
            {
                Debug.LogWarning(
                    $"Calling {nameof(GetMonitorUnitsForTarget)} before profiling has completed. " +
                    $"If you need to access units during initialization consider disabling async profiling in the monitoring settings!");
            }

            var list = ListPool<IMonitorUnit>.Get();
            var monitorUnits = _monitoringManager.GetInstanceUnits();
            for (var i = 0; i <monitorUnits.Count; i++)
            {
                var instanceUnit = monitorUnits[i];
                if (instanceUnit.Target == target)
                {
                    list.Add(instanceUnit);
                }
            }
            var returnValue = list.ToArray();
            ListPool<IMonitorUnit>.Release(list);
            return returnValue;
        }

    }
}