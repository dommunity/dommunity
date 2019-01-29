using System;

namespace Dommunity.Node.Tests.Messaging
{
    class BazMessage
    {
        public static readonly Guid Id = new Guid("6a20541e-36ec-4c14-96e5-1037b107de8d");

        public BazMessage(double value1)
        {
            Value1 = value1;
        }

        public double Value1 { get; }
    }
}
