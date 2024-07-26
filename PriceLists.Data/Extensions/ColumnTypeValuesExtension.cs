using PriceLists.Data.Enums;

namespace PriceLists.Data.Extensions;

public static class ColumnTypeValuesExtension
{
    public static string GetNameOfColumnType(this ColumnTypeValues value) =>
        value switch
        {
            ColumnTypeValues.Numeric => "Число",
            ColumnTypeValues.String => "Строка",
            ColumnTypeValues.Text => "Текст",
            _ => throw new NotImplementedException("Тип не найден."),
        };
}
