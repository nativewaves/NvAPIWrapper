﻿using NvAPIWrapper.Native.Attributes;
using NvAPIWrapper.Native.General.Structures;
using NvAPIWrapper.Native.Helpers;
using NvAPIWrapper.Native.Interfaces;
using NvAPIWrapper.Native.Interfaces.Display;
using System.Runtime.InteropServices;

namespace NvAPIWrapper.Native.Display.Structures
{
    /// <inheritdoc cref="IHDRCapabilities" />
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [StructureVersion(1)]
    public struct HDRCapabilitiesV1 : IInitializable, IHDRCapabilities
    {
        internal StructureVersion _Version;
        internal uint _RawReserved;
        internal StaticMetadataDescriptorId _StaticMetadataDescriptorId;
        internal DisplayData _DisplayData;

        public HDRCapabilitiesV1(
            bool driverExpandDefaultHDRParameters,
            StaticMetadataDescriptorId staticMetadataDescriptorId = StaticMetadataDescriptorId.StaticMetadataType1,
            DisplayData displayData = default)
        {
            this = typeof(HDRCapabilitiesV1).Instantiate<HDRCapabilitiesV1>();
            DriverExpandDefaultHDRParameters = driverExpandDefaultHDRParameters;
            _StaticMetadataDescriptorId = staticMetadataDescriptorId;
            _DisplayData = displayData;
        }

        public HDRCapabilitiesV1(bool driverExpandDefaultHDRParameters, StaticMetadataDescriptorId staticMetadataDescriptorId)
            : this(driverExpandDefaultHDRParameters, staticMetadataDescriptorId, default)
        {
        }

        /// <inheritdoc />
        public StaticMetadataDescriptorId StaticMetadataDescriptorId
        {
            get => _StaticMetadataDescriptorId;
        }

        /// <inheritdoc />
        public DisplayData DisplayData
        {
            get => _DisplayData;
        }

        /// <inheritdoc />
        public bool IsST2084EOTFSupported
        {
            get => _RawReserved.GetBit(0);
            private set => _RawReserved = _RawReserved.SetBit(0, value);
        }

        /// <inheritdoc />
        public bool IsTraditionalHDRGammaSupported
        {
            get => _RawReserved.GetBit(1);
            private set => _RawReserved = _RawReserved.SetBit(1, value);
        }

        /// <inheritdoc />
        public bool IsEDRSupported
        {
            get => _RawReserved.GetBit(2);
            private set => _RawReserved = _RawReserved.SetBit(2, value);
        }

        /// <inheritdoc />
        public bool DriverExpandDefaultHDRParameters
        {
            get => _RawReserved.GetBit(3);
            private set => _RawReserved = _RawReserved.SetBit(3, value);
        }

        /// <inheritdoc />
        public bool IsTraditionalSDRGammaSupported
        {
            get => _RawReserved.GetBit(4);
            private set => _RawReserved = _RawReserved.SetBit(4, value);
        }
    }
}
