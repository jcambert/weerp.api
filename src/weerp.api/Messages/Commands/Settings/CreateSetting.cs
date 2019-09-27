
using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.api.Messages.Commands.Products
{
    [MessageNamespace("settings")]
    public class CreateSetting : ICommand
    {
        [JsonConstructor]


        public CreateSetting(Guid id,
            int numero,
            string description,
            string type,
            string stringValue,
            int? intValue,
            double? doubleValue,
            DateTime? dtValue)
        {
            Id = id;
            Numero = numero;
            Description = description;
            Type = type;
            StringValue = stringValue;
            IntegerValue = intValue;
            DoubleValue = doubleValue;
            DateValue = dtValue;
        }

        public readonly Guid Id;
        public readonly int Numero;

        public string Description { get; }

        public readonly string Type;

        public readonly string StringValue;

        public readonly int? IntegerValue;

        public readonly double? DoubleValue;

        public readonly DateTime? DateValue;
    }
}
