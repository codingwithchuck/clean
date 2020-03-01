﻿using Clean.Common.Notifications;

 namespace Momntz.Common.Dispatches
{
    public class SuccessDispatch : IDispatch
    {
        public SuccessDispatch()
        {
        }

        public SuccessDispatch(string message)
        {
            Message = message;
        }

        public DispatchType DispatchType { get; } = DispatchType.Info;

        public string Message { get; set; } = string.Empty;
    }
}