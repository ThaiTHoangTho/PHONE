using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KATPHONE.Models
{
    public class OrderModelView
    {
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string TENKH { get; set; }
        [Phone]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DIACHI { get; set; }
        public string EMAIL { get; set; }
        public int THANHTOAN { get; set; }
    }
}