using Smart_Warehouse.Models.Entities;

namespace Smart_Warehouse.Models.Respones.Warehouse
{
    public class WarehouseResponse : BaseEntity
    {
        /// <summary>
        /// Tên nhà kho
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Địa chỉ nhà kho
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }


        /// <summary>
        /// Số lượng tối đa có thể lưu trữ của sản phẩm 
        /// </summary>
        public int MaxStock { get; set; }

        /// <summary>
        /// Số lượng hiện tại
        /// </summary>
        public int CurrentStock { get; set; }

    }
}
