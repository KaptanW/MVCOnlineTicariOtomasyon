namespace MVCOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 30, unicode: false),
                        Sifre = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        CariId = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(maxLength: 30, unicode: false),
                        CariUnvan = c.String(),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CariId);
            
            CreateTable(
                "dbo.SatisHarakets",
                c => new
                    {
                        SatisId = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cariler_CariId = c.Int(),
                        Personel_PersonelId = c.Int(),
                        Urun_UrunId = c.Int(),
                    })
                .PrimaryKey(t => t.SatisId)
                .ForeignKey("dbo.Carilers", t => t.Cariler_CariId)
                .ForeignKey("dbo.Personels", t => t.Personel_PersonelId)
                .ForeignKey("dbo.Uruns", t => t.Urun_UrunId)
                .Index(t => t.Cariler_CariId)
                .Index(t => t.Personel_PersonelId)
                .Index(t => t.Urun_UrunId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        Departman_Departmanid = c.Int(),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Departmen", t => t.Departman_Departmanid)
                .Index(t => t.Departman_Departmanid);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        Departmanid = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Departmanid);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Kategoriid = c.Int(nullable: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Kategoris", t => t.Kategoriid, cascadeDelete: true)
                .Index(t => t.Kategoriid);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fatura_FaturaId = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaKalemId)
                .ForeignKey("dbo.Faturalars", t => t.Fatura_FaturaId)
                .Index(t => t.Fatura_FaturaId);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        FaturaId = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSıraNo = c.String(maxLength: 6, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.DateTime(nullable: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.FaturaId);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Fatura_FaturaId", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarakets", "Urun_UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "Kategoriid", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarakets", "Personel_PersonelId", "dbo.Personels");
            DropForeignKey("dbo.Personels", "Departman_Departmanid", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarakets", "Cariler_CariId", "dbo.Carilers");
            DropIndex("dbo.FaturaKalems", new[] { "Fatura_FaturaId" });
            DropIndex("dbo.Uruns", new[] { "Kategoriid" });
            DropIndex("dbo.Personels", new[] { "Departman_Departmanid" });
            DropIndex("dbo.SatisHarakets", new[] { "Urun_UrunId" });
            DropIndex("dbo.SatisHarakets", new[] { "Personel_PersonelId" });
            DropIndex("dbo.SatisHarakets", new[] { "Cariler_CariId" });
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarakets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
