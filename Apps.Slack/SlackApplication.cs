﻿using Apps.Slack.Connections.OAuth2;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;

namespace Apps.Slack
{
    public class SlackApplication : IApplication
    {
        public string Name
        {
            get => "Slack";
            set { }
        }
        private readonly Dictionary<Type, object> _typesInstances;

        public SlackApplication()
        {
            _typesInstances = CreateTypesInstances();
        }

        public T GetInstance<T>()
        {
            if (!_typesInstances.TryGetValue(typeof(T), out var value))
            {
                throw new InvalidOperationException($"Instance of type '{typeof(T)}' not found");
            }
            return (T)value;
        }

        private Dictionary<Type, object> CreateTypesInstances()
        {
            return new Dictionary<Type, object>
            {
                { typeof(IOAuth2AuthorizeService), new OAuth2AuthorizationSerivce() },
                { typeof(IOAuth2TokenService), new OAuth2TokenService() }
            };
        }
    }
}
