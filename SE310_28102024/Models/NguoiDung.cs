using System;
using System.Collections.Generic;

namespace SE310_WebAPI.Models
{
    public partial class NguoiDung
    {
        public int NguoiDungId { get; set; }
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Quyen { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
