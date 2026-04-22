using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Smart_Warehouse.Common
{
    public class Enums
    {
        public enum InventoryLogType
        {
            Import = 0,
            Export = 1,
            Adjustment = 2
        }

        public enum Status
        {
            [Display(Name = "Đang đợi")]
            Pending = 0,

            [Display(Name = "Đã duyệt")]
            Approved = 1,

            [Display(Name = "Từ chối")]
            Rejected = 2,

            [Display(Name = "Hoàn thành")]
            Completed = 3,

            [Display(Name = "Thất bại")]
            Failed = 4,

            [Display(Name = "Tất cả")]
            All = 5
        }

    }

}
public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        if (enumValue == null) return string.Empty;

        var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
        if (memberInfo == null) return enumValue.ToString();

        var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
        return displayAttribute?.Name ?? enumValue.ToString();
    }

    // Optional: Nếu bạn muốn fallback về DescriptionAttribute
    public static string GetDescription(this Enum enumValue)
    {
        var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
        if (memberInfo == null) return enumValue.ToString();

        var descriptionAttribute = memberInfo.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
        return descriptionAttribute?.Description ?? enumValue.GetDisplayName();
    }
}
