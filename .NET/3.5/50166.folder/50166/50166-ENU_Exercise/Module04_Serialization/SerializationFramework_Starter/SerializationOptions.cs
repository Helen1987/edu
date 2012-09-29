using System;

namespace SerializationFramework
{
    /// <summary>
    /// Describes the serialization traits for a field.
    /// The Encrypt and Compress values can be combined as bit-flags.
    /// </summary>
    [Flags]
    public enum SerializationOptions
    {
        /// <summary>
        /// Serialize the field in the default way.
        /// </summary>
        Default = 0x0,
        /// <summary>
        /// Encrypt the field's contents before serializing it.
        /// </summary>
        Encrypt = 0x1,
        /// <summary>
        /// Compress the field's contents before serializing it.
        /// </summary>
        Compress = 0x2,
        /// <summary>
        /// Omit this field from serialization.  When using this
        /// value, the DynamicDeserializationBehavior enumeration
        /// determines how the field's value will be obtained when
        /// deserialization occurs.
        /// </summary>
        Omit = 0x4
    }

    /// <summary>
    /// Describes the deserialization behavior for fields which are omitted
    /// from serialization.
    /// </summary>
    public enum DynamicDeserializationBehavior
    {
        /// <summary>
        /// Use the default value when deserializing the field.
        /// </summary>
        UseDefaultValue,
        /// <summary>
        /// Invoke the method marked with the [DeserializationCallback]
        /// attribute with the field name as a parameter, e.g.:
        ///     [DeserializationCallback("_myField"]
        ///     void DeserializeMyField() { ... }
        /// </summary>
        InvokeCallback
    }
}
