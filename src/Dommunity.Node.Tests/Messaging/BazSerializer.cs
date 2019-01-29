using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Node.Messaging;

namespace Dommunity.Node.Tests.Messaging
{
    class BazSerializer : IMessageSerializer
    {
        public Task<object> DeserializeAsync(
            IRemoteNode sender,
            Guid messageId,
            int payloadSize,
            Stream payload,
            CancellationToken cancellationToken)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (payloadSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(payloadSize));
            }

            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            object message;

            if (messageId == BazMessage.Id)
            {
                if (payloadSize < 8)
                {
                    throw new InvalidMessageException();
                }

                using (var reader = new BinaryReader(payload, Encoding.UTF8, true))
                {
                    var value1 = reader.ReadDouble();

                    message = new BazMessage(value1);
                }
            }
            else
            {
                message = null;
            }

            return Task.FromResult(message);
        }

        public async Task<bool> SerializeAsync(
            IRemoteNode receiver,
            object message,
            StartSerializeAsync start,
            CancellationToken cancellationToken)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException(nameof(receiver));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (start == null)
            {
                throw new ArgumentNullException(nameof(start));
            }

            if (message is BazMessage)
            {
                var output = await start(BazMessage.Id, 8, cancellationToken);

                using (var writer = new BinaryWriter(output, Encoding.UTF8, true))
                {
                    writer.Write(((BazMessage)message).Value1);
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
