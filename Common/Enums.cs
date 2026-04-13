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
            Pending = 0,
            Approved = 1,
            Rejected = 2,
            Complete = 3
        }
    }
}
