using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Entities.Orders
{
    public class Export : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// Người lập phiếu xuất
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Khóa ngoại người dùng (navigation property)
        /// </summary>
        public virtual User User { get; set; } = null!;
        
        /// <summary>
        /// Id nhà kho
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public Status Status { get; set; } = Status.Pending;

        /// <summary>
        /// Danh sách chi tiết phiếu xuất (navigation property)
        /// </summary>
        public virtual ICollection<ExportDetail> Details { get; set; } = new List<ExportDetail>();
    }
}
