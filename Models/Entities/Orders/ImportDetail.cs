using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Warehouse.Models.Entities.Order
{
    public class ImportDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Id phiếu nhập
        /// </summary>
        public int ImportId { get; set; }

        /// <summary>
        /// Khóa ngoại phiếu nhập (navigation property)
        /// </summary>
        public virtual Import Import { get; set; } = null!;

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Khóa ngoại sản phẩm (navigation property)
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Sô lượng
        /// </summary>
        public int Quantity { get; set; }
    }
}
