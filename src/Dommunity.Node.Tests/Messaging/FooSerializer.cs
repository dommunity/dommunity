using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Node.Messaging;

namespace Dommunity.Node.Tests.Messaging
{
    class FooSerializer : IMessageSerializer
    {
        public static Stream CreateFooPayload(int value1)
        {
            var payload = new MemoryStream();

            try
            {
                WriteFooPayload(payload, value1);
                payload.Seek(0, SeekOrigin.Begin);
            }
            catch
            {
                payload.Close();
                throw;
            }

            return payload;
        }

        public static void WriteFooPayload(Stream output, int value1)
        {
            using (var writer = new BinaryWriter(output, Encoding.UTF8, true))
            {
                writer.Write(value1);
            }
        }

        public Task<object> DeserializeAsync(
            IRemoteNode sender,
            Guid messageId,
            int payloadSize,
            Stream payload,
            CancellationToken cancellationToken)
        {
            object message;

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

            if (messageId == FooMessage.Id)
            {
                if (payloadSize != FooMessage.Size)
                {
                    throw new InvalidMessageException();
                }

                using (var reader = new BinaryReader(payload, Encoding.UTF8, true))
                {
                    var value1 = reader.ReadInt32();
                    if (value1 < 0)
                    {
                        throw new InvalidMessageException();
                    }

                    message = new FooMessage(value1);
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

            if (message is FooMessage)
            {
                var output = await start(FooMessage.Id, FooMessage.Size, cancellationToken);
                WriteFooPayload(output, ((FooMessage)message).Value1);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
