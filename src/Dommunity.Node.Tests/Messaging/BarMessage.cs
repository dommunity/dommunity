using System;

namespace Dommunity.Node.Tests.Messaging
{
    class BarMessage
    {
        public static readonly Guid Id = new Guid("65e6fc79-bb98-41b4-8d33-4e813cd22a6b");

        public BarMessage(string value1)
        {
            Value1 = value1;
        }

        public string Value1 { get; }
    }
}
