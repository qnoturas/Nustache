namespace Nustache.Core.Tests
{
    /// <summary>
    /// For testing that an object that contains a matching property but that property is set to null.
    /// </summary>
    public class TestObject
    {
        public object Foo { get; set; }

        public TestObject NestedFoo { get; set; }
    }
}
