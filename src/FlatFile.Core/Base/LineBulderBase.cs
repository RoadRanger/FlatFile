namespace FlatFile.Core.Base
{
    public abstract class LineBulderBase<TLayoutDescriptor, TFieldSettings> : ILineBulder
        where TLayoutDescriptor : ILayoutDescriptor<TFieldSettings>
        where TFieldSettings : IFieldSettingsContainer 
    {
        private readonly TLayoutDescriptor _descriptor;

        protected LineBulderBase(TLayoutDescriptor descriptor)
        {
            this._descriptor = descriptor;
        }

        protected TLayoutDescriptor Descriptor
        {
            get { return _descriptor; }
        }

        public abstract string BuildLine<T>(T entry);

        protected virtual string GetStringValueFromField(TFieldSettings field, object fieldValue)
        {
            if (fieldValue == null)
            {
                return field.NullValue;
            }

            string lineValue = fieldValue.ToString();

            lineValue = TransformFieldValue(field, lineValue);

            return lineValue;
        }

        protected virtual string TransformFieldValue(TFieldSettings field, string lineValue)
        {
            return lineValue;
        }
    }
}