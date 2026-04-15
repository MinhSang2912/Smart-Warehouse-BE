using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Entities.Order
{
    public class Import : BaseEntity
    {
        /// <summary>
        /// Mã phiếu nhập
        /// </summary>
        public string Code { get; set; } = string.Empty;        

        /// <summary>
        /// Id người lập
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Khóa ngoại người lập (navigation property)
        /// </summary>
        public virtual User User { get; set; } = null!;

        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Id Kho hàng nhập vào
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Khóa ngoại kho hàng (navigation property)
        /// </summary>
        public virtual Warehouse Warehouse { get; set; } = null!;

        /// <summary>
        /// Trạng thái phiếu nhập
        /// </summary>
        public Status Status { get; set; } = Status.Pending;

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Ngày nhận hàng
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// Tên người nhận hàng
        /// </summary>
        public string? Receiver { get; set; }

        /// <summary>
        /// Tên người vận chuyển
        /// </summary>
        public string? Carrier { get; set; }

        /// <summary>
        /// Tên người duyệt
        /// </summary>
        public string? Approver { get; set; }

        /// <summary>
        /// Lấy danh sách chi tiết phiếu nhập (navigation property)
        /// </summary>
        public virtual ICollection<ImportDetail> Details { get; set; } = new List<ImportDetail>();
    }
}
