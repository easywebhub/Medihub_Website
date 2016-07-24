using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medihub.Commons
{
    public class GlobalsEnum
    {
        public enum GlobalStatus
        {
            AccessDenied,
            Success,
            UnSuccess,
            Failed,
            InvalidData,
            Account_Unauthorized,
            Account_Login_NotAllow,
            Account_Login_Failed,
            Account_Login_WrongUsernameOrPassword,
        }
        public enum GlobalOrderStatus
        {
            Donhangmoi =1,
            SansanchuyenVTa = 2,
            DachuyenVTa = 3,
            VNPdanhanhang = 4,
            VTAhethang = 5,
            Giaohangthanhcong = 6,
            Giaohangthatbai = 7,
            Huy = 8,
            Huydohethang = 9,
            Khachhangtra = 10,
            ChuaLayConfirmCode = 100,   // dang o trang thai SansanchuyenVTa = 2
            ChuaGoiDonhangsangSO = 101, // da lay confirm code
            ChuagoiMail = 102,           // sau khi da lay confirm code, da goi don hang sang SO
            ChuagoiSMS = 103,           // sau khi da lay confirm code, da goi don hang sang SO, da send mail
            DagoiSMS = 104,        // sau khi da lay confirm code, da goi don hang sang SO, da send mail, da send sms
            XNlan1 = 14, // Xác nhận lần 1
            ChuyenOnline= 19, //Đã bấm chuyển đơn hàng sang online   
            DonhangmoiTragop = 18, //đơn hàng trả góp trạng thái mới    
        }

      
        public enum UserStatus
        {
            NotActiveYet,
            Active,
            Lock,
            Deleted
        }
        public enum PaymentType
        {
            ThanhToanKhiNhanHang = 14,
            ThanhToanTraGop = 18,
            ChuyenKhoan = 16,
            ThanhToanOnline = 21
        }
        public enum Company
        {
            PPF =101
           
        }
        
        
        
    }
}
