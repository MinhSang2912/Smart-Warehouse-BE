namespace Smart_Warehouse.Common
{
    public class Message
    {
        #region Role
        public static readonly string RoleNotFound = "Không tìm thấy vai trò";
        #endregion

        #region User
        public static readonly string UserNotFound = "Không tìm thấy người dùng";
        public static readonly string InvalidPassword = "Mật khẩu không đúng";
        public static readonly string PasswordNotNull = "Mật khẩu không được để trống";
        public static readonly string UserNotNull = "Tên đăng nhập không được để trống";
        public static readonly string UserAlreadyExists = "Người dùng đã tồn tại";
        public static readonly string UserCreated = "Người dùng đã được tạo thành công";
        public static readonly string UserUpdated = "Người dùng đã được cập nhật thành công";
        public static readonly string PasswordChange = "Mật khẩu đã được thay đổi thành công";
        public static readonly string Unauthorized = "Không có quyền truy cập";
        public static readonly string UserDeleted = "Thành công xóa người dùng";

        #endregion

        #region Category
        public static readonly string CategoryNotFound = "Không tìm thấy danh mục";
        public static readonly string CategoryAlreadyExists = "Danh mục đã tồn tại";
        public static readonly string CategoryHaveProduct = "Danh mục vẫn còn sản phẩm";
        public static readonly string CategoryCreated = "Danh mục đã được tạo thành công";
        public static readonly string CategoryUpdated = "Danh mục đã được cập nhật thành công";
        public static readonly string CategoryDeleted = "Thành công xóa danh mục";
        #endregion

        #region Product
        public static readonly string ProductNotFound = "Không tìm thấy sản phẩm";
        public static readonly string ProductAlreadyExists = "Sản phẩm đã tồn tại";
        public static readonly string ProductCreated = "San phẩm đã được tạo thành công";
        public static readonly string ProductUpdated = "Sản phẩm đã được cập nhật thành công";
        public static readonly string ProductDeleted = "Thành công xóa sản phẩm";
        public static readonly string ProductMinThreshold = "Sản phẩm đã đạt ngưỡng tối thiểu, cần nhập thêm hàng";
        public static readonly string PriceMustBePositive = "Giá sản phẩm phải là số dương";
        public static readonly string ProductNoInventory = "Sản phẩm này chưa có tồn kho";


        #endregion

        #region Supplier
        public static readonly string SupplierNotFound = "Không tìm thấy nhà cung cấp";
        public static readonly string SupplierAlreadyExists = "Nhà cung cấp đã tồn tại";
        public static readonly string SupplierCreated = "Nhà cung cấp đã được tạo thành công";
        public static readonly string SupplierUpdated = "Nhà cung cấp đã được cập nhật thành công";
        public static readonly string SupplierDeleted = "Thành công xóa nhà cung cấp";
        #endregion

        #region Warehouse
        public static readonly string WarehouseNotFound = "Không tìm thấy nhà kho";
        public static readonly string WarehouseNotNull = "Nhà kho không được rỗng";
        public static readonly string WarehouseAlreadyExists = "Nhà kho đã tồn tại";
        public static readonly string WarehouseOverMaxStock = "Số lượng vượt quá sức chứa nhà kho";
        public static readonly string WarehouseCreated = "Thành công tạo nhà kho";
        public static readonly string WarehouseUpdated = "Thành công cập nhật nhà kho";
        public static readonly string WarehouseDeleted = "Xóa nhà kho thành công";
        #endregion

        #region Inventory
        public static readonly string InventoryNotFound = "Không tìm thấy tồn kho";
        public static readonly string InventoryAlreadyExists = "Tồn kho đã tồn tại";
        public static readonly string MaxStockExceeded = "Vượt quá tồn kho tối đa";
        public static readonly string NotEnoughtStock = "Không đủ số lượng tồn";
        public static readonly string InventoryCreated = "Thành công tạo tồn kho";
        public static readonly string InventoryUpdated = "Thành công cập nhật tồn kho";
        public static readonly string InventoryDeleted = "Xóa tồn kho thành công";
        #endregion

        #region ImportExport
        public static readonly string ImportInValid = "Phiếu nhập không hợp lệ";
        public static readonly string ImportCreated = "Tạo phiếu nhập thành công";
        public static readonly string ImportUpdate = "Cập nhật phiếu thành công";
        public static readonly string ExportInValid = "Phiếu xuất không hợp lệ";
        public static readonly string ImportNotFound = "Không tìm thấy phiếu nhập";
        public static readonly string ExportNotFound = "Không tìm thấy phiếu xuất";
        public static readonly string ImportDetailNotFound = "Không tìm thấy chi tiết phiếu nhập";
        public static readonly string ImportDetailCreated = "Thành công tạo chi tiết phiếu nhập";
        public static readonly string ImportDetailUpdated = "Thành công cập nhật chi tiết phiếu nhập";
        public static readonly string ExportCreated = "Tạo phiếu xuất thành công";
        public static readonly string ExportUpdated = "Thành công cập nhật phiếu xuất";
        public static readonly string QuantityHigherZero = "Sô lượng phải lớn hơn 0";
        public static readonly string ExceedingQuantity = "Vượt quá số lượng tồn kho";
        #endregion
    }
}
