using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class MissingLocalizationWeatherException(Localization localization) 
        : PackITException($"Couldn't fetch weather data from localiztion {localization.City}/{localization.Country}.")
    {
    }
}
