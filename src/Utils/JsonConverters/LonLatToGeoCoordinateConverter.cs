﻿//-----------------------------------------------------------------------
// <copyright file="LonLatToGeoCoordinateConverter.cs" company="Mapbox">
//     Copyright (c) 2016 Mapbox. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Mapbox
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Bbox to geo coordinate bounds converter.
    /// </summary>
    public class LonLatToGeoCoordinateConverter : CustomCreationConverter<GeoCoordinate>
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Mapbox.LonLatToGeoCoordinateConverter"/> can write.
        /// </summary>
        /// <value><c>true</c> if can write; otherwise, <c>false</c>.</value>
        public override bool CanWrite
        {
            get { return true; }
        }

        /// <summary>
        /// Create the specified objectType.
        /// </summary>
        /// <param name="objectType">Object type.</param>
        /// <returns>A <see cref="GeoCoordinate"/>.</returns>
        public override GeoCoordinate Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create the specified objectType and jArray.
        /// </summary>
        /// <param name="objectType">Object type.</param>
        /// <param name="val">Jarray representing a two length array of coordinates.</param>
        /// <returns>A <see cref="GeoCoordinate"/>.</returns>
        public GeoCoordinate Create(Type objectType, JArray val)
        {
            return new GeoCoordinate((double)val[0], (double)val[1]);
        }

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">A <see cref="JsonWriter"/>.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">A <see cref="JsonSerializer"/>.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var val = (GeoCoordinate)value;

            serializer.Serialize(writer, val.ToArray());
        }

        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <returns>The serialized object.</returns>
        /// <param name="reader">A reader.</param>
        /// <param name="objectType">Object type.</param>
        /// <param name="existingValue">Existing value.</param>
        /// <param name="serializer">A <see cref="JsonSerializer"/>.</param>
        /// <returns>An object.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray coordinates = JArray.Load(reader);

            return Create(objectType, coordinates);
        }
    }
}
