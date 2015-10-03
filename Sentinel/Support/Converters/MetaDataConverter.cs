namespace Sentinel.Support.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Data;

    public class MetaDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var member = parameter as string;
            var metaData = value as IDictionary<string, object>;

            if (metaData != null && !string.IsNullOrWhiteSpace(member))
            {
                object metaDataValue;
                metaData.TryGetValue(member, out metaDataValue);
                return metaDataValue;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}