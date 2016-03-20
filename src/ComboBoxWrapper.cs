using System;

namespace ResxTranslator
{
    public class ComboBoxWrapper<T>
    {
        public ComboBoxWrapper()
        {
        }

        public ComboBoxWrapper(T wrappedObject)
        {
            WrappedObject = wrappedObject;
        }

        public ComboBoxWrapper(T wrappedObject, Func<T, string> toStringConverter) : this(wrappedObject)
        {
            ToStringConverter = toStringConverter;
        }

        public T WrappedObject { get; set; }
        public Func<T, string> ToStringConverter { get; set; }

        public override string ToString()
        {
            return ToStringConverter == null ? WrappedObject.ToString() : ToStringConverter(WrappedObject);
        }
    }
}