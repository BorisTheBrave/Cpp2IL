# Call Analyzer

This processing layer analyzes method instructions for calls to other methods and emits attributes based on that.

For this processor, 8 new attributes are injected:
```cs
using System;
namespace Cpp2ILInjected.CallAnalysis;

/// <summary>
/// This method's instructions have been deduplicated by the compiler, and it shares its address with other methods.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class DeduplicatedMethodAttribute : Attribute
{
}

/// <summary>
/// A problem was encountered while analyzing this method's instructions.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class CallAnalysisFailedAttribute : Attribute
{
}

/// <summary>
/// This method has no instructions to analyze and is not abstract nor an interface declaration.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class CallAnalysisNotSupportedAttribute : Attribute
{
}

/// <summary>
/// This method is called from the method specified.
/// </summary>
/// <remarks>
/// This attribute is not emitted if there are a large amount of callers.
/// </remarks>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class CalledByAttribute : Attribute
{
	public Type? Type;

	public string? TypeFullName;

	public string Member;
}

/// <summary>
/// This method calls the method specified.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class CallsAttribute : Attribute
{
	public Type? Type;

	public string? TypeFullName;

	public string Member;
}

/// <summary>
/// The number of direct calls to this method.
/// </summary>
/// <remarks>
/// This attribute is similar in form and function to the one generated by <see href="https://github.com/knah/Il2CppAssemblyUnhollower">Unhollower</see>.
/// </remarks>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class CallerCountAttribute : Attribute
{
	public int Count;
}

/// <summary>
/// This method calls at least one deduplicated method.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class CallsDeduplicatedMethodsAttribute : Attribute
{
	public int Count;
}

/// <summary>
/// This method calls at least one unknown method.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class CallsUnknownMethodsAttribute : Attribute
{
	public int Count;
}
```
