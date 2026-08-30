using System.Reflection;
using System.Text.Json.Serialization;

using RadioBrowser.Exceptions;

using RestSharp;

namespace RadioBrowser.Extensions;

public static class RestRequestExtensions
{
    extension(RestRequest request)
    {
        /// <summary>
        /// Adds string and enum properties from the specified object
        /// to the request as query parameters.
        /// </summary>
        /// <typeparam name="T">The type containing query parameters.</typeparam>
        /// <param name="parameters">The object containing query parameter values.</param>
        /// <returns>The current <see cref="RestRequest"/> instance.</returns>
        /// <exception cref="RadioBrowserException">
        /// Thrown when a property type is unsupported or an enum value is invalid.
        /// </exception>
        public RestRequest AddQueryParameters<T>(T? parameters) where T : class
        {
            if (parameters is null)
                return request;

            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                if (!property.CanRead || property.GetIndexParameters().Length > 0)
                    continue;

                var value = property.GetValue(parameters);

                if (value is null)
                    continue;

                var parameterName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;
                var parameterValue = ConvertToQueryParameter(value);
                request.AddQueryParameter(parameterName, parameterValue);
            }

            return request;
        }
    }

    private static string ConvertToQueryParameter(object value)
    {
        return value switch
        {
            string stringValue => stringValue,
            Enum enumValue => GetEnumValue(enumValue),
            bool boolValue => boolValue ? "true" : "false",
            _ => throw new RadioBrowserException($"Query parameter type '{value.GetType().Name}' is not supported.")
        };
    }

    private static string GetEnumValue(Enum value)
    {
        var enumType = value.GetType();
        var enumName = Enum.GetName(enumType, value) ?? throw new RadioBrowserException($"Value '{value}' is not defined in enum '{enumType.Name}'.");
        var enumMember = enumType.GetField(enumName);
        return enumMember?.GetCustomAttribute<JsonStringEnumMemberNameAttribute>()?.Name ?? enumName;
    }
}