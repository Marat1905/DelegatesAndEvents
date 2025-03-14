namespace DelegatesAndEvents.Extensions
{
    public static class GetMaxExtension
    {
        public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
           if (collection is null)
                throw new ArgumentNullException(nameof(collection));
           if (convertToNumber is null)
                throw new ArgumentNullException(nameof(convertToNumber));

            float maxValue = float.MinValue;
            T? maxElement = default;

            foreach (T element in collection)
            {
                float value = convertToNumber(element);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxElement = element;
                }
            }

            return maxElement;
        }
    }
}
