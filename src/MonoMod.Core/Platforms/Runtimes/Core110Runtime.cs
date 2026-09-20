using MonoMod.Utils;
using System;
using static MonoMod.Core.Interop.CoreCLR;

namespace MonoMod.Core.Platforms.Runtimes
{
    internal class Core110Runtime : Core100Runtime
    {
        public Core110Runtime(ISystem system, IArchitecture arch) : base(system, arch) { }

        // src/coreclr/inc/jiteeversionguid.h (v11.0.0-rc.1.26425.128)
        // 0d18a7df-af1f-4481-a72f-aa6cf8aa0a65
        private static readonly Guid JitVersionGuid110 = new(
            0x0d18a7df,
            0xaf1f,
            0x4481,
            0xa7, 0x2f, 0xaa, 0x6c, 0xf8, 0xaa, 0x0a, 0x65
        );

        protected override Guid ExpectedJitVersion => JitVersionGuid110;

        protected override int VtableIndexICorJitInfoAllocMem => V110.ICorJitInfoVtable.AllocMemIndex;
        protected override int ICorJitInfoFullVtableCount => V110.ICorJitInfoVtable.TotalVtableCount;
    }
}
