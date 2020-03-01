﻿using Clean.Common.Notifications;

 namespace Momntz.Common.Dispatches
{
    public class InfoDispatch : IDispatch
    {
        public InfoDispatch()
        {
        }

        public InfoDispatch(string message)
        {
            Message = message;
        }

        public DispatchType DispatchType { get; } = DispatchType.Info;
        public string Message { get; set; } = string.Empty;
    }
}