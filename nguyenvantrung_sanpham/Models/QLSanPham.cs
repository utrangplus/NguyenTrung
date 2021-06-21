using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace nguyenvantrung_sanpham.Models
{
    public class QLSanPham
    {
        public int ID { set; get; }

        [Required(ErrorMessage ="Bạn Cần Nhập Vào Mã SP")]
        [Display(Name ="Mã Sản Phẩm")]
        public string MaSP { set; get; }

        [Required(ErrorMessage ="Bạn Cần Nhập Vào Tên SP")]
        [Display(Name ="Tên Sản Phẩm")]
        public string TenSP { set; get; }

        [Required(ErrorMessage ="Bạn Cần Nhập Vào Số Lượng SP")]
        [Display(Name ="Số lượng")]
        public int Solg { set; get; }

        [Required(ErrorMessage ="Bạn Cần Nhập Vào Giá SP")]
        [Display(Name ="Giá ")]
        public int Gia { set; get; }

    }

    class SanPhamList
    {
        DBConnection db;
        public SanPhamList()
        {
            db = new DBConnection();
        }

        //Phương thức lấy dữ liệu SP từ CSDL
        public List<QLSanPham> getSanPham(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM SanPham";
            }
            else
            {
                sql = "SELECT * FROM SanPham WHERE id = " + ID;
            }

            List<QLSanPham> strList = new List<QLSanPham>();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối:
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối:
            cmd.Dispose();
            con.Close();

            QLSanPham strSP;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                strSP = new QLSanPham();

                strSP.ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                strSP.MaSP = dt.Rows[i]["MaSP"].ToString();
                strSP.TenSP = dt.Rows[i]["TenSP"].ToString();
                strSP.Solg = Convert.ToInt32(dt.Rows[i]["Solg"].ToString());
                strSP.Gia = Convert.ToInt32(dt.Rows[i]["Gia"].ToString());

                strList.Add(strSP);
            }

            return strList;
        }

        //Them du lieu
        public void AddSanPham(QLSanPham strSP)
        {
            string sql = "INSERT INTO SanPham(MaSP, TenSP, Solg, Gia)VALUES(N'"+strSP.MaSP+"', N'"+strSP.TenSP+"', N'"+strSP.Solg+"', N'"+strSP.Gia+"')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối:
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối:
            cmd.Dispose();
            con.Close();

        }

        //Sửa dữ liệu:
        public void EditSanPham(QLSanPham strSP)
        {
            string sql = "UPDATE SanPham SET MaSP = N'" + strSP.MaSP + "', TenSP = N'" + strSP.TenSP + "', Solg = N'" + strSP.Solg + "', Gia = N'" + strSP.Gia + "' WHERE Id = "+strSP.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở Kết nối:
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối:
            cmd.Dispose();
            con.Close();
        }

        //Xoá dữ liệu:
        public void DeleteSanPham(QLSanPham strSP)
        {
            string sql = "DELETE FROM SanPham WHERE Id = " + strSP.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở Kết nối:
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối:
            cmd.Dispose();
            con.Close();
        }

    }
}