using nguyenvantrung_sanpham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nguyenvantrung_sanpham.Controllers
{
    public class SanPhamsController : Controller
    {
        // GET: SanPhams
        public ActionResult Index()
        {
            SanPhamList strSP = new SanPhamList();
            List<QLSanPham> obj = strSP.getSanPham(string.Empty);
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QLSanPham strSP)
        {
            if (ModelState.IsValid)
            {
                SanPhamList SP = new SanPhamList();
                SP.AddSanPham(strSP);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Sửa Sản Phẩm:
        public ActionResult Edit(string id = "")
        {
            SanPhamList SP = new SanPhamList();
            List<QLSanPham> obj = SP.getSanPham(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]

        public ActionResult Edit(QLSanPham strSP)
        {
            SanPhamList SP = new SanPhamList();
            SP.EditSanPham(strSP);
            return RedirectToAction("Index");
        }

        //Xoá Sản Phẩm:
        public ActionResult Delete(string id = "")
        {
            SanPhamList SP = new SanPhamList();
            List<QLSanPham> obj = SP.getSanPham(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]

        public ActionResult Delete(QLSanPham strSP)
        {
            SanPhamList SP = new SanPhamList();
            SP.DeleteSanPham(strSP);
            return RedirectToAction("Index");
        }

        //Chi tiết Sản Phẩm:
        public ActionResult Details(string id = "")
        {
            SanPhamList SP = new SanPhamList();
            List<QLSanPham> obj = SP.getSanPham(id);
            return View(obj.FirstOrDefault());
        }
    }
}