﻿namespace Clean.FeatureSets.Common
{
    public interface IModel<TModel>
    {
        TModel Model { get; set; }
    }
}