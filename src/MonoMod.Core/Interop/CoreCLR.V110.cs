using System.Diagnostics.CodeAnalysis;

namespace MonoMod.Core.Interop
{
    internal static unsafe partial class CoreCLR
    {
        [SuppressMessage("Performance", "CA1812", Justification = "Non-static so it can inherit V100.")]
        public class V110 : V100
        {
            public new static class ICorJitInfoVtable
            {
                // Derived from dotnet/runtime v11.0.0-rc.1.26425.128 (corinfo.h / corjit.h), method names only.
                //
                // class ICorStaticInfo
                // 00: isIntrinsic
                // 01: canValueClassInstancePointerEscape
                // 02: notifyMethodInfoUsage
                // 03: getMethodAttribs
                // 04: setMethodAttribs
                // 05: getMethodSig
                // 06: getMethodInfo
                // 07: haveSameMethodDefinition
                // 08: getTypeDefinition
                // 09: canInline
                // 0A: beginInlining
                // 0B: reportInliningDecision
                // 0C: canTailCall
                // 0D: reportTailCallDecision
                // 0E: getEHinfo
                // 0F: getMethodClass
                // 10: getMethodVTableOffset
                // 11: resolveVirtualMethod
                // 12: getAsyncOtherVariant
                // 13: getDefaultComparerClass
                // 14: getDefaultEqualityComparerClass
                // 15: getSZArrayHelperEnumeratorClass
                // 16: expandRawHandleIntrinsic
                // 17: isIntrinsicType
                // 18: getUnmanagedCallConv
                // 19: pInvokeMarshalingRequired
                // 1A: satisfiesMethodConstraints
                // 1B: methodMustBeLoadedBeforeCodeIsRun
                // 1C: getGSCookie
                // 1D: setPatchpointInfo
                // 1E: getOSRInfo
                // 1F: resolveToken
                // 20: findSig
                // 21: findCallSiteSig
                // 22: getTokenTypeAsHandle
                // 23: getStringLiteral
                // 24: printObjectDescription
                // 25: asCorInfoType
                // 26: getClassNameFromMetadata
                // 27: getTypeInstantiationArgument
                // 28: getMethodInstantiationArgument
                // 29: printClassName
                // 2A: isValueClass
                // 2B: getClassAttribs
                // 2C: getClassAssemblyName
                // 2D: LongLifetimeMalloc
                // 2E: LongLifetimeFree
                // 2F: getIsClassInitedFlagAddress
                // 30: getClassStaticDynamicInfo
                // 31: getClassThreadStaticDynamicInfo
                // 32: getStaticBaseAddress
                // 33: getClassSize
                // 34: getHeapClassSize
                // 35: canAllocateOnStack
                // 36: getClassAlignmentRequirement
                // 37: getClassGClayout
                // 38: getClassNumInstanceFields
                // 39: getFieldInClass
                // 3A: getTypeLayout
                // 3B: checkMethodModifier
                // 3C: getNewHelper
                // 3D: getNewArrHelper
                // 3E: getCastingHelper
                // 3F: getSharedCCtorHelper
                // 40: getTypeForBox
                // 41: getBoxHelper
                // 42: getUnBoxHelper
                // 43: getRuntimeTypePointer
                // 44: isObjectImmutable
                // 45: getStringChar
                // 46: getObjectType
                // 47: getReadyToRunHelper
                // 48: getReadyToRunDelegateCtorHelper
                // 49: initClass
                // 4A: classMustBeLoadedBeforeCodeIsRun
                // 4B: getBuiltinClass
                // 4C: getTypeForPrimitiveValueClass
                // 4D: getTypeForPrimitiveNumericClass
                // 4E: canCast
                // 4F: compareTypesForCast
                // 50: compareTypesForEquality
                // 51: isMoreSpecificType
                // 52: isExactType
                // 53: isGenericType
                // 54: isNullableType
                // 55: isEnum
                // 56: getParentType
                // 57: getChildType
                // 58: isSDArray
                // 59: getArrayRank
                // 5A: getArrayIntrinsicID
                // 5B: getArrayInitializationData
                // 5C: canAccessClass
                // 5D: printFieldName
                // 5E: getFieldClass
                // 5F: getFieldType
                // 60: getFieldOffset
                // 61: getFieldInfo
                // 62: getThreadLocalFieldInfo
                // 63: getThreadLocalStaticBlocksInfo
                // 64: getThreadLocalStaticInfo_NativeAOT
                // 65: isFieldStatic
                // 66: getArrayOrStringLength
                // 67: getBoundaries
                // 68: setBoundaries
                // 69: getVars
                // 6A: setVars
                // 6B: reportRichMappings
                // 6C: reportAsyncDebugInfo
                // 6D: reportMetadata
                // 6E: allocateArray
                // 6F: freeArray
                // 70: getArgNext
                // 71: getArgType
                // 72: getExactClasses
                // 73: getArgClass
                // 74: getHFAType
                // 75: runWithErrorTrap
                // 76: runWithSPMIErrorTrap
                // 77: getEEInfo
                // 78: getAsyncInfo
                // 79: getAwaitReturnCall
                // 7A: getAwaitAwaiterInContinuationCall
                // 7B: getMethodDefFromMethod
                // 7C: printMethodName
                // 7D: getMethodNameFromMetadata
                // 7E: getMethodHash
                // 7F: getSystemVAmd64PassStructInRegisterDescriptor
                // 80: getSwiftLowering
                // 81: getFpStructLowering
                // 82: getWasmLowering
                // 83: getAddressAlignment
                // 84: getWasmWellKnownGlobals
                //
                // class ICorDynamicInfo : public ICorStaticInfo
                // 85: getThreadTLSIndex
                // 86: getAddrOfCaptureThreadGlobal
                // 87: getHelperFtn
                // 88: getFunctionEntryPoint
                // 89: getFunctionFixedEntryPoint
                // 8A: embedModuleHandle
                // 8B: embedClassHandle
                // 8C: embedMethodHandle
                // 8D: embedFieldHandle
                // 8E: embedGenericHandle
                // 8F: getLocationOfThisType
                // 90: getAddressOfPInvokeTarget
                // 91: GetCookieForPInvokeCalliSig
                // 92: GetCookieForInterpreterCalliSig
                // 93: getJustMyCodeHandle
                // 94: GetProfilingHandle
                // 95: getCallInfo
                // 96: getStaticFieldContent
                // 97: getObjectContent
                // 98: getStaticFieldCurrentClass
                // 99: getVarArgsHandle
                // 9A: constructStringLiteral
                // 9B: emptyStringLiteral
                // 9C: getFieldThreadLocalStoreID
                // 9D: GetDelegateCtor
                // 9E: MethodCompileComplete
                // 9F: getTailCallHelpers
                // A0: getAsyncResumptionStub
                // A1: getContinuationType
                // A2: convertPInvokeCalliToCall
                // A3: notifyInstructionSetUsage
                // A4: updateEntryPointForTailCall
                // A5: getWasmTypeSymbol
                // A6: getSpecialCopyHelper
                //
                // class ICorJitInfo : public ICorDynamicInfo
                // A7: allocMem
                public const int AllocMemIndex = 0xA7;
                // A8: reserveUnwindInfo
                // A9: allocUnwindInfo
                // AA: allocGCInfo
                // AB: setEHcount
                // AC: setEHinfo
                // AD: logMsg
                // AE: doAssert
                // AF: reportFatalError
                // B0: getPgoInstrumentationResults
                // B1: allocPgoInstrumentationBySchema
                // B2: recordCallSite
                // B3: recordWasmManagedCallSig
                // B4: recordRelocation
                // B5: getRelocTypeHint
                // B6: getExpectedTargetArchitecture
                // B7: getJitFlags

                public const int TotalVtableCount = 0xB8;
            }
        }
    }
}
