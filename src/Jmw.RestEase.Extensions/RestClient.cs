// <copyright file="RestClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jmw.RestEase.Extensions
{
    using System;
    using System.Net.Http;
    using Jmw.Extensions.Http;

    /// <summary>
    /// Extensions For <see cref="global::RestEase.RestClient" />.
    /// </summary>
    public class RestClient
    {
        /// <summary>
        /// Creates a RestEase client using <see cref="NLogHttpClientHandler" />.
        /// </summary>
        /// <typeparam name="T">Interface representing the API</typeparam>
        /// <param name="baseUrl">Base URL</param>
        /// <returns>An implementation of that interface which you can use to invoke the API</returns>
        public static T For<T>(string baseUrl)
        {
            if (baseUrl == null)
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            var httpClient = new HttpClient(new NLogHttpClientHandler())
            {
                BaseAddress = new Uri(baseUrl)
            };

            return global::RestEase.RestClient.For<T>(httpClient);
        }
    }
}
