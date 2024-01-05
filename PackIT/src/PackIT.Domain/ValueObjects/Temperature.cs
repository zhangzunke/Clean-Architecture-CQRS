﻿using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record Temperature
    {
        public double Value { get; }
        public Temperature(double value) 
        {
            if (value is < -100 or > 100)
                throw new InvalidTemperatureException(value);
        }
        public static implicit operator Temperature(double temperature)
           => new(temperature);
        public static implicit operator double(Temperature temperature)
            => temperature.Value;
    }
}
