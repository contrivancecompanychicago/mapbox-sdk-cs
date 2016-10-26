﻿//-----------------------------------------------------------------------
// <copyright file="GeocodeResponse.cs" company="Mapbox">
//     Copyright (c) 2016 Mapbox. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Mapbox.Geocoding
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary> Base geocode response. </summary>
    [Serializable]
    public abstract class GeocodeResponse
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type", Order = 0)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        /// <value>The features.</value>
        [JsonProperty("features", Order = 2)]
        public List<Feature> Features { get; set; }

        /// <summary>
        /// Gets or sets the attribution.
        /// </summary>
        /// <value>The attribution.</value>
        [JsonProperty("attribution", Order = 3)]
        public string Attribution { get; set; }
    }

    /// <summary>
    /// Reverse Geocode response.
    /// </summary>
    [Serializable]
    public class GeoCodeResponseReverse : GeocodeResponse
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>The query.</value>
        [JsonProperty("query", Order = 1)]
        public List<double> Query { get; set; }
    }

    /// <summary>
    /// Forward geocode response.
    /// </summary>
    [Serializable]
    public class GeoCodeResponseForward : GeocodeResponse
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>The query.</value>
        [JsonProperty("query", Order = 1)]
        public List<string> Query { get; set; }
    }
}