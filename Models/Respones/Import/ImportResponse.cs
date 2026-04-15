using Smart_Warehouse.Common;
using Smart_Warehouse.Models.Entities.Order;
using Smart_Warehouse.Models.Respones.ImportDetail;
using static Smart_Warehouse.Common.Enums;

namespace Smart_Warehouse.Models.Respones.Import
{
    public class ImportResponse
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
        /// Tên người dùng
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Id Kho hàng nhập vào
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Tên nhà kho
        /// </summary>
        public string? WarehouseName { get; set; }

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
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        public virtual List<ImportDetailResponse> Details { get; set; } = new();
    }
}
