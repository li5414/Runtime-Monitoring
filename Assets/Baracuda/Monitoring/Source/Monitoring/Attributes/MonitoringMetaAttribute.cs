// Copyright (c) 2022 Jonathan Lang

using Baracuda.Monitoring.Interfaces;
using System;
using UnityEngine.Scripting;

namespace Baracuda.Monitoring.Attributes
{
    /// <summary>
    /// Attributes inheriting from this class can be used to provide monitoring units with additional meta data.
    /// These attributes will be cached on the Monitoring Profile and can be queried with <see cref="IMonitorProfile.TryGetMetaAttribute{TAttribute}"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Class)]
    [Preserve]
    public abstract class MonitoringMetaAttribute : Attribute
    {
    }
}