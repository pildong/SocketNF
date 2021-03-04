﻿using System;
using System.Threading.Tasks;

using Shared;
using Shared.Json;
using Shared.Xml;

namespace Server
{
    public class MessageHandler
    {
        //Handler on the 'Server' side of the system
        [XPathRoute( "/Message[@type='Request' and @action='HeartBeat']" )]
        [JsonRoute( "$.action", "HeartBeat" )]
        public static Task<HeartBeatResponseMessage> HandleMessage( HeartBeatRequestMessage request )
        {
            Received( request );
            var response = new HeartBeatResponseMessage {
                Id = request.Id,
                POSData = request.POSData,
                Result = new Result { Status = Status.Success}
            };
            Sending( response );
            return Task.FromResult( response );
        }

        //Handler on the 'Server' side of the system
        [XPathRoute( "/Message[@type='Request' and @action='SubmitBasket']" )]
        [JsonRoute( "$.action", "SubmitBasket" )]
        public static Task<SubmitBasketResponse> HandleMessage( SubmitBasketRequest request )
        {
            Received( request );
            var response = new SubmitBasketResponse {
                Id = request.Id,
                POSData = request.POSData,
                Result = new Result { Status = Status.Success}
            };
            Sending( response );
            return Task.FromResult( response );
        }

        static void Received<T>( T msg ) where T : Message
            => Console.WriteLine( $"Received {typeof( T ).Name}: Action[ {msg.Action} ], Id[ {msg.Id} ]" );

        static void Sending<T>( T msg ) where T : Message
            => Console.WriteLine( $"Received {typeof( T ).Name}: Action[ {msg.Action} ], Id[ {msg.Id} ]" );
    }
}
