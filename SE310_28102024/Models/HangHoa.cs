using System;
using System.Collections.Generic;

namespace SE310_WebAPI.Models
{
    public partial class HangHoa
    {
        public int HangHoaId { get; set; }
        public string TenHang { get; set; } = null!;
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string? MoTa { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? Img { get; set; }
    }
}
