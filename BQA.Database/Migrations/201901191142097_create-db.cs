namespace BQA.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        IdFacebook = c.String(maxLength: 50),
                        IdGoogle = c.String(maxLength: 50),
                        TokenActive = c.String(maxLength: 100),
                        isActived = c.Boolean(nullable: false),
                        SoLanDangNhapSai = c.Int(nullable: false),
                        KhoaTaiKhoanDen = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.GroupOfAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAccount = c.Int(nullable: false),
                        IdGroup = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.IdAccount, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.IdGroup, cascadeDelete: true)
                .Index(t => t.IdAccount)
                .Index(t => t.IdGroup);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 50),
                        MoTa = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGroup = c.Int(nullable: false),
                        IdChucNang = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChucNang", t => t.IdChucNang, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.IdGroup, cascadeDelete: true)
                .Index(t => t.IdGroup)
                .Index(t => t.IdChucNang);
            
            CreateTable(
                "dbo.ChucNang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdScreen = c.Int(nullable: false),
                        TenChucNang = c.String(nullable: false, maxLength: 50),
                        MoTa = c.String(maxLength: 200),
                        ControllerName = c.String(nullable: false, maxLength: 50),
                        ActionName = c.String(nullable: false, maxLength: 50),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ManHinh", t => t.IdScreen, cascadeDelete: true)
                .Index(t => t.IdScreen);
            
            CreateTable(
                "dbo.ManHinh",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenManHinh = c.String(nullable: false, maxLength: 50),
                        MoTa = c.String(maxLength: 200),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TokenLogin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAccount = c.Int(nullable: false),
                        Token = c.String(nullable: false, maxLength: 100),
                        ThoiGianTonTai = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.IdAccount, cascadeDelete: true)
                .Index(t => t.IdAccount);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ho = c.String(nullable: false, maxLength: 50),
                        Ten = c.String(nullable: false, maxLength: 50),
                        GioiTinh = c.Boolean(nullable: false),
                        NgaySinh = c.DateTime(storeType: "date"),
                        SoDienThoai = c.String(maxLength: 15),
                        CMND = c.String(maxLength: 12),
                        DiaChi = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BinhLuan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        IdBinhLuanCha = c.Int(),
                        IdTinTuc = c.Int(nullable: false),
                        NoiDung = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BinhLuan", t => t.IdBinhLuanCha)
                .ForeignKey("dbo.TinTuc", t => t.IdTinTuc, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdBinhLuanCha)
                .Index(t => t.IdTinTuc);
            
            CreateTable(
                "dbo.TinTuc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinkAnh = c.String(nullable: false, maxLength: 50),
                        NoiDung = c.String(nullable: false),
                        TieuDe = c.String(nullable: false, maxLength: 255),
                        ThoiGian = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DongHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdTrangThai = c.Int(nullable: false),
                        NgayLap = c.DateTime(nullable: false),
                        DiaChiGiao = c.String(),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrangThai", t => t.IdTrangThai, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.IdTrangThai);
            
            CreateTable(
                "dbo.DonDatHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSanPham = c.Int(nullable: false),
                        IdDonHang = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DongHang", t => t.IdDonHang, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.IdSanPham, cascadeDelete: true)
                .Index(t => t.IdSanPham)
                .Index(t => t.IdDonHang);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMauSac = c.Int(nullable: false),
                        IdDanhCho = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        LinkAnh = c.String(nullable: false, maxLength: 255),
                        LinkAnh1 = c.String(maxLength: 255),
                        LinkAnh2 = c.String(maxLength: 255),
                        giaSP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoLuong = c.Int(nullable: false),
                        KichThuoc = c.String(maxLength: 50),
                        KhuyenMai = c.Single(nullable: false),
                        TienPhaiTra = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DanhCho", t => t.IdDanhCho, cascadeDelete: true)
                .ForeignKey("dbo.MauSac", t => t.IdMauSac, cascadeDelete: true)
                .Index(t => t.IdMauSac)
                .Index(t => t.IdDanhCho);
            
            CreateTable(
                "dbo.DanhCho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MauSac",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrangThai",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LienHe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrangThai = c.Int(nullable: false),
                        HoTen = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 255),
                        NoiDung = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrangThai", t => t.IdTrangThai, cascadeDelete: true)
                .Index(t => t.IdTrangThai);
            
            CreateTable(
                "dbo.CaiDatHeThong",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiaChi = c.String(nullable: false, maxLength: 255),
                        SoDienThoai = c.String(nullable: false, maxLength: 15),
                        LinkFB = c.String(nullable: false, maxLength: 255),
                        LinkGG = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        SoLanChoPhepDangNhapSai = c.Int(nullable: false),
                        ThoiGianKhoa = c.Int(nullable: false),
                        KinhDo = c.Single(nullable: false),
                        ViDo = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorMgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mgs = c.String(nullable: false, maxLength: 255),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinkAnh = c.String(nullable: false, maxLength: 255),
                        TieuDe = c.String(nullable: false, maxLength: 255),
                        ChiTiet = c.String(nullable: false, maxLength: 1000),
                        Link = c.String(nullable: false, maxLength: 255),
                        HienThi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DongHang", "IdUser", "dbo.User");
            DropForeignKey("dbo.LienHe", "IdTrangThai", "dbo.TrangThai");
            DropForeignKey("dbo.DongHang", "IdTrangThai", "dbo.TrangThai");
            DropForeignKey("dbo.SanPham", "IdMauSac", "dbo.MauSac");
            DropForeignKey("dbo.DonDatHang", "IdSanPham", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "IdDanhCho", "dbo.DanhCho");
            DropForeignKey("dbo.DonDatHang", "IdDonHang", "dbo.DongHang");
            DropForeignKey("dbo.BinhLuan", "IdUser", "dbo.User");
            DropForeignKey("dbo.BinhLuan", "IdTinTuc", "dbo.TinTuc");
            DropForeignKey("dbo.BinhLuan", "IdBinhLuanCha", "dbo.BinhLuan");
            DropForeignKey("dbo.Account", "IdUser", "dbo.User");
            DropForeignKey("dbo.TokenLogin", "IdAccount", "dbo.Account");
            DropForeignKey("dbo.Permission", "IdGroup", "dbo.Group");
            DropForeignKey("dbo.Permission", "IdChucNang", "dbo.ChucNang");
            DropForeignKey("dbo.ChucNang", "IdScreen", "dbo.ManHinh");
            DropForeignKey("dbo.GroupOfAccount", "IdGroup", "dbo.Group");
            DropForeignKey("dbo.GroupOfAccount", "IdAccount", "dbo.Account");
            DropIndex("dbo.LienHe", new[] { "IdTrangThai" });
            DropIndex("dbo.SanPham", new[] { "IdDanhCho" });
            DropIndex("dbo.SanPham", new[] { "IdMauSac" });
            DropIndex("dbo.DonDatHang", new[] { "IdDonHang" });
            DropIndex("dbo.DonDatHang", new[] { "IdSanPham" });
            DropIndex("dbo.DongHang", new[] { "IdTrangThai" });
            DropIndex("dbo.DongHang", new[] { "IdUser" });
            DropIndex("dbo.BinhLuan", new[] { "IdTinTuc" });
            DropIndex("dbo.BinhLuan", new[] { "IdBinhLuanCha" });
            DropIndex("dbo.BinhLuan", new[] { "IdUser" });
            DropIndex("dbo.TokenLogin", new[] { "IdAccount" });
            DropIndex("dbo.ChucNang", new[] { "IdScreen" });
            DropIndex("dbo.Permission", new[] { "IdChucNang" });
            DropIndex("dbo.Permission", new[] { "IdGroup" });
            DropIndex("dbo.GroupOfAccount", new[] { "IdGroup" });
            DropIndex("dbo.GroupOfAccount", new[] { "IdAccount" });
            DropIndex("dbo.Account", new[] { "IdUser" });
            DropTable("dbo.Slide");
            DropTable("dbo.ErrorMgs");
            DropTable("dbo.CaiDatHeThong");
            DropTable("dbo.LienHe");
            DropTable("dbo.TrangThai");
            DropTable("dbo.MauSac");
            DropTable("dbo.DanhCho");
            DropTable("dbo.SanPham");
            DropTable("dbo.DonDatHang");
            DropTable("dbo.DongHang");
            DropTable("dbo.TinTuc");
            DropTable("dbo.BinhLuan");
            DropTable("dbo.User");
            DropTable("dbo.TokenLogin");
            DropTable("dbo.ManHinh");
            DropTable("dbo.ChucNang");
            DropTable("dbo.Permission");
            DropTable("dbo.Group");
            DropTable("dbo.GroupOfAccount");
            DropTable("dbo.Account");
        }
    }
}
