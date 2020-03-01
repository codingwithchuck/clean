﻿using Clean.Common.Notifications;

 namespace Momntz.Common.Dispatches
{
    public class WarningDispatch : IDispatch
    {
        public WarningDispatch()
        {
        }

        public WarningDispatch(string message)
        {
            Message = message;
        }

        public DispatchType DispatchType { get; } = DispatchType.Warning;
        public string Message { get; set; } = string.Empty;
    }
}