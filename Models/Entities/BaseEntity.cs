using Smart_Warehouse.Models.Entities.Inventories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Warehouse.Models.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id của thực thể
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Dùng để đánh dấu thực thể có đang hoạt động hay không
        /// (để tránh xóa dữ liệu vật lý, chỉ cần đánh dấu là không hoạt động).
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Ngay giờ thực thể được tạo ra (sử dụng UTC để tránh vấn đề múi giờ).
        /// </summary>
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Ngày giờ cập nhật 
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
