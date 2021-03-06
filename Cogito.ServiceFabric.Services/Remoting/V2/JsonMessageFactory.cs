﻿using Microsoft.ServiceFabric.Services.Remoting.V2;

namespace Cogito.ServiceFabric.Services.Remoting.V2
{

    class JsonMessageFactory : IServiceRemotingMessageBodyFactory
    {

        public IServiceRemotingRequestMessageBody CreateRequest(string interfaceName, string methodName, int numberOfParameters, object wrappedRequestObject)
        {
            return new JsonRemotingRequestBody();
        }

        public IServiceRemotingResponseMessageBody CreateResponse(string interfaceName, string methodName, object wrappedResponseObject)
        {
            return new JsonRemotingResponseBody();
        }
    }

}
