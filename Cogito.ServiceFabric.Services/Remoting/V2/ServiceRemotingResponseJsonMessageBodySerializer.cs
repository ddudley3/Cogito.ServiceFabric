﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.ServiceFabric.Services.Remoting.V2;
using Microsoft.ServiceFabric.Services.Remoting.V2.Messaging;

using Newtonsoft.Json;

namespace Cogito.ServiceFabric.Services.Remoting.V2
{

    class ServiceRemotingResponseJsonMessageBodySerializer : IServiceRemotingResponseMessageBodySerializer
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceInterfaceType"></param>
        /// <param name="responseWrappedTypes"></param>
        /// <param name="responseBodyTypes"></param>
        public ServiceRemotingResponseJsonMessageBodySerializer(
            Type serviceInterfaceType,
            IEnumerable<Type> responseWrappedTypes,
            IEnumerable<Type> responseBodyTypes)
        {

        }

        public IOutgoingMessageBody Serialize(IServiceRemotingResponseMessageBody responseMessageBody)
        {
            using (var stream = new MemoryStream())
            {
                // serialize to stream
                using (var writer = new JsonTextWriter(new StreamWriter(stream, Encoding.UTF8)))
                    JsonSerializerConfig.Serializer.Serialize(writer, responseMessageBody);
                
                return new OutgoingMessageBody(new[] { new ArraySegment<byte>(stream.ToArray()) });
            }
        }

        public IServiceRemotingResponseMessageBody Deserialize(IIncomingMessageBody messageBody)
        {
            using (var reader = new JsonTextReader(new StreamReader(messageBody.GetReceivedBuffer())))
                return JsonSerializerConfig.Serializer.Deserialize<JsonRemotingResponseBody>(reader);
        }

    }

}
