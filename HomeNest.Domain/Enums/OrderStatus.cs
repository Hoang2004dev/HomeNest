namespace HomeNest.Domain.Enums;

public enum OrderStatus
{
    Pending = 0,     // chờ xác nhận
    Paid = 1,        // đã thanh toán
    Processing = 2,  // đang xử lý
    Shipped = 3,     // đã giao cho đơn vị vận chuyển
    Delivered = 4,   // đã giao đến khách
    Completed = 5,   // hoàn tất
    Cancelled = 6    // bị hủy
}
