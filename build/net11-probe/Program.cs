// Canary: hooks a method through MonoMod.RuntimeDetour on whatever runtime this process runs on, then undoes it.
// Usage: net11-probe <expectedRuntimeMajor>. Exit 0 = ran on that runtime major AND hook + undo both behaved.
// The Fun.Build pipeline (ci-net11.fsx) runs it on .NET 10 and, via roll-forward, on the newest .NET 11 runtime.
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MonoMod.RuntimeDetour;

Console.WriteLine($"runtime: {RuntimeInformation.FrameworkDescription}");
if (args is not [var expected] || Environment.Version.Major.ToString() != expected)
{
    Console.Error.WriteLine($"expected to run on .NET {args.FirstOrDefault() ?? "?"} but this is .NET {Environment.Version.Major}");
    return 3;
}

var target = typeof(Probe).GetMethod(nameof(Probe.Foo), BindingFlags.Public | BindingFlags.Static)!;
using (var hook = new Hook(target, new Func<int>(() => 42)))
{
    var hooked = Probe.Foo();
    Console.WriteLine($"hooked   Foo() = {hooked} (expect 42)");
    if (hooked != 42) return 1;
}

var undone = Probe.Foo();
Console.WriteLine($"unhooked Foo() = {undone} (expect 1)");
return undone == 1 ? 0 : 2;

public static class Probe
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Foo() => 1;
}
