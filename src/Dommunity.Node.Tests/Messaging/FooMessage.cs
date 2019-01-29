using System;

namespace Dommunity.Node.Tests.Messaging
{
    class FooMessage
    {
        public const int Size = 4;

        public static readonly Guid Id = new Guid("0701b00d-cb61-41f4-a6fd-aa67e7f5d217");

        public FooMessage(int value1)
        {
            Value1 = value1;
        }

        public int Value1 { get; }
    }
}
