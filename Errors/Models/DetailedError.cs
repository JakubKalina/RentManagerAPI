﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Validation.Models
{
    public class DetailedError
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorParameters")]
        public IEnumerable<string> ErrorParameters { get; set; }

        [JsonProperty("isArchived")]
        public bool IsArchived { get; set; }

        [JsonProperty("description")]
        public string Description
        {
            get
            {
                var requiredParams = Regex.Matches(DescriptionFormatter, @"(?<!\{)\{([0-9]+).*?\}(?!})").Cast<Match>();

                if (requiredParams.Any())
                {
                    if (ErrorParameters == null)
                        throw new ArgumentException($"Nie podano parametrów do formattera");

                    if (requiredParams.Count() != ErrorParameters.Count())
                        throw new ArgumentException($"Nieprawidłowa liczba parametrów formatowania wiadomości zwrotnej. Podano {ErrorParameters.Count()} zamiast ${requiredParams.Count()}");

                    object[] errorParametersArray = ErrorParameters.ToArray();
                    return string.Format(DescriptionFormatter, args: errorParametersArray);
                }

                return DescriptionFormatter;
            }
        }

        [JsonIgnore]
        public string DescriptionFormatter { get; set; }

        public DetailedError SetParams(params string[] errorParameters)
        {
            var errorParametersList = errorParameters == null ? new List<string>() : errorParameters.ToList();
            var requiredParameters = Regex.Matches(DescriptionFormatter, @"(?<!\{)\{([0-9]+).*?\}(?!})")
                .Cast<Match>();

            int requiredParameterCount = requiredParameters.Count();
            if (errorParametersList.Count() != requiredParameterCount)
                throw new ArgumentException($"Nieprawidłowa liczba parametrów formatowania wiadomości zwrotnej. Podano {errorParametersList.Count} zamiast ${requiredParameterCount}");

            return new DetailedError
            {
                DescriptionFormatter = DescriptionFormatter,
                ErrorCode = ErrorCode,
                ErrorParameters = errorParametersList
            };
        }
    }
}