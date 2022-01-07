using System;

/// <summary>
/// Summary description for Class1
/// </summary>
[Serializable]
public class NoProductException : Exception
{
    public NoProductException() : base() { }
    public NoProductException(string message) : base(message) { }
    public NoProductException(string message, Exception inner) : base(message, inner) { }

    protected NoProductException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctx) : base(info, ctx) { }
}
