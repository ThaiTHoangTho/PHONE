using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KATPHONE.Models
{
    public class GIOHANG
    {
        public List<CTGH> Items { get; set; }
        public GIOHANG()
        {
            this.Items = new List<CTGH>();
        }
        public void Addtocart(CTGH item, int quantity)
        {
            var checkExits = Items.FirstOrDefault(x => x.MASP == item.MASP);
            if (checkExits != null)
            {
                checkExits.SOLUONG += quantity;
                checkExits.TONGTIEN = checkExits.GIABAN * checkExits.SOLUONG;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(x => x.MASP == id);
            if (checkExits != null)
            {
                Items.Remove(checkExits);

            }
        }
        public void UpdateQuanity(int id, int quantity)
        {
            var checkExits = Items.SingleOrDefault(x => x.MASP == id);
            if (checkExits != null)
            {
                checkExits.SOLUONG = quantity;
                checkExits.TONGTIEN = checkExits.GIABAN * checkExits.SOLUONG;
            }

        }
        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.TONGTIEN);
        }
        public int GetTotalQuanity()
        {
            return Items.Sum(x => x.SOLUONG);
        }
        public void Clear()
        {
            Items.Clear();
        }
    }
    public class CTGH
    {
            public int MASP { get; set; }
            public string TENSP { get; set; }
            public string TENNSX { get; set; }
            public string ANH { get; set; }
            public int SOLUONG { get; set; }
            public decimal GIABAN { get; set; }
            public decimal TONGTIEN { get; set; }
    }
}