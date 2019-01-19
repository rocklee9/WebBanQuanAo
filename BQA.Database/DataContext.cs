using BQA.DataBase.Schema;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BQA.DataBase
{
    public class DataContext : DbContext
    {
        

        public DataContext()
           : base(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=WebBanQuanAo;User Id=sa;Password=123456;Integrated Security=True;")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<CaiDatHeThong> CaiDatHeThong { get; set; }
        public virtual DbSet<ChucNang> ChucNang { get; set; }
        public virtual DbSet<DanhCho> DanhCho { get; set; }
        public virtual DbSet<DonDatHang> DonDatHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<ErrorMgs> ErrorMgs { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupOfAccount> GroupOfAccount { get; set; }
        public virtual DbSet<LienHe> LienHe { get; set; }
        public virtual DbSet<ManHinh> ManHinh { get; set; }
        public virtual DbSet<MauSac> MauSac { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }
        public virtual DbSet<TokenLogin> TokenLogin { get; set; }
        public virtual DbSet<TrangThai> TrangThai { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}