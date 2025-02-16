using LibCpp2IL.BinaryStructures;

namespace Cpp2IL.Core.Model.Contexts;

/// <summary>
/// Represents any kind of type context that is not a basic type definition. This includes generic instantiations, byref/pointer types, arrays, etc.
/// </summary>
public abstract class ReferencedTypeAnalysisContext : TypeAnalysisContext
{
    public abstract Il2CppTypeEnum Type { get; } //Must be set by derived classes

    protected override int CustomAttributeIndex => -1;

    public override AssemblyAnalysisContext CustomAttributeAssembly => DeclaringAssembly;

    protected ReferencedTypeAnalysisContext(AssemblyAnalysisContext referencedFrom) : base(null, referencedFrom)
    {
    }

    public override string ToString()
    {
        return DefaultName;
    }

    public override string GetCSharpSourceString()
    {
        return Name;
    }
}
