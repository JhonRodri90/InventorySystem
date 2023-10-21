using DataTransferObjets.Dto.Out;

namespace BusinessLogic.AbstractLogic.Application
{
    internal static class GenericValidation
    {
        private const int NoRecords = 0;
        private const string valueId = "Id";
        private const string valueName = "Name";

        public static bool HasRecords<T>(IEnumerable<T> listItemsValidation)
        {
            int? quantityRecords = listItemsValidation?.Count();
            return (listItemsValidation != null && quantityRecords > NoRecords);
        }

        public static bool NotIsNull<T>(T itemValidation) => (itemValidation != null);


        public static bool ValidateNullField<T>(T data, params Predicate<T>[] Validations)
        {
            return Validations.ToList().Any(x =>
            {
                return x(data);
            });
        }

        public static readonly Predicate<MarkResponse>[] Validations = {
            (d) => d.Name != null,
        };

        public static bool ValidateDuplicateNameField<T>(IEnumerable<T> data, int id, string name)
        {
            return id == 0 ? data.Any(b => b.GetType().GetProperty(valueName).GetValue(b)
            .ToString().ToLower().Trim() == name.ToLower().Trim()) :
                data.Any(b => b.GetType().GetProperty(valueName).GetValue(b).ToString()
                .ToLower().Trim() == name.ToLower().Trim() && Convert.ToInt32(b.GetType().GetProperty(valueId).GetValue(b)) != id);
        }
    }
}
