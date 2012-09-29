using System;

namespace SerializationFramework
{
    /// <summary>
    /// Describes the serialization traits for a field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class SerializationAttribute : Attribute
    {
        private readonly SerializationOptions _options;
        private readonly DynamicDeserializationBehavior _dynamicBehavior;

        public SerializationAttribute(SerializationOptions options)
            : this(options, DynamicDeserializationBehavior.UseDefaultValue)
        {
        }

        public SerializationAttribute(SerializationOptions options, DynamicDeserializationBehavior dynamicBehavior)
        {
            if ((options & SerializationOptions.Omit) != 0 && dynamicBehavior != DynamicDeserializationBehavior.InvokeCallback)
            {
                throw new ArgumentException("When using SerializationOptions.Omit, " +
                    "the DynamicDeserializationBehavior.InvokeCallback value is invalid " +
                    "because no callback will be invoked.");
            }

            _options = options;
            _dynamicBehavior = dynamicBehavior;
        }

        public SerializationOptions SerializationOptions { get { return _options; } }

        public DynamicDeserializationBehavior DynamicDeserializationBehavior { get { return _dynamicBehavior; } }
    }

    /// <summary>
    /// Denotes a deserialization callback for a field that was omitted from serialization.
    /// The single mandatory parameter to this attribute is the field name.
    /// The method should not have any parameters and should have a void return value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class DeserializationCallbackAttribute : Attribute
    {
        private readonly string _fieldName;

        public string FieldName { get { return _fieldName; } }

        public DeserializationCallbackAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }
    }
}
