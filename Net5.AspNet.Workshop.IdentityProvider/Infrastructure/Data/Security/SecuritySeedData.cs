using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Net5.AspNet.Workshop.IdentityProvider.Infrastructure.Data.Security.Contexts;
using Net5.AspNet.Workshop.IdentityProvider.Infrastructure.Data.Security.Entities;
using Net5.AspNet.Workshop.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Infrastructure.Data.Security
{
    public static class SecuritySeedData
    {
        static Category AWS;
        static Category QA;
        static Category BD;
        static Category JAVA;
        static Category NET;
        static Category Microservices;
        static Category Azure;
        static Category Agile;
        static Category DevOps;
        static Category Architecture;

        static IdentityRole AdministratorRole;
        static IdentityRole Instructor;
        static IdentityRole PowerUser;
        static IdentityRole Enrolled;
        static IdentityRole User;

        static Department Lima;
        static Department Tumbes;
        static Department Arequipa;
        static Department Ancash;
        static Department Ayacucho;

        static Province LimaProvince;
        static Province Huaral;
        static Province TumbesProvince;
        static Province Zarumilla;
        static Province ArequipaProvince;
        static Province Camana;
        static Province Huaraz;
        static Province Yungay;
        static Province Huamanga;
        static Province Sucre;

        static District LimaDistrict;
        static District SanJuandeLurigancho;
        static District HuaralDistrict;
        static District Chancay;
        static District TumbesDistrict;
        static District SanJacinto;
        static District ZarumillaDistrict;
        static District AguasVerdes;
        static District ArequipaDistrict;
        static District JoseLuisBustamanteyRivero;
        static District CamanaDistrict;
        static District Ocona;
        static District HuarazDistrict;
        static District Colcabamba;
        static District YungayDistrict;
        static District Cascapara;
        static District AcosVinchos;
        static District AndresAvelinoCaceresDorregaray;
        static District Querobamba;
        static District SantiagodePaucaray;

        static Person Administrator;
        static Person Bill;
        static Person Jeff;
        static Person Alexander;
        static Person Edgard;
        static Person James;
        static Person Igor;
        static Person Zakaria;
        static Person Dionisio;
        static Person Hassan;
        static Person Esteban;
        static Person Aina;
        static Person Jesusa;
        static Person Elisabeth;
        static Person Leticia;
        static Person Maite;

        static ApplicationUser AdministratorUser;
        static ApplicationUser BillUser;
        static ApplicationUser JeffUser;
        static ApplicationUser AlexanderUser;
        static ApplicationUser EdgardUser;
        static ApplicationUser JamesUser;
        static ApplicationUser IgorUser;
        static ApplicationUser ZakariaUser;
        static ApplicationUser DionisioUser;
        static ApplicationUser HassanUser;
        static ApplicationUser EstebanUser;
        static ApplicationUser AinaUser;
        static ApplicationUser JesusaUser;
        static ApplicationUser ElisabethUser;
        static ApplicationUser LeticiaUser;
        static ApplicationUser MaiteUser;

        public static void Initialize(IServiceProvider services)
        {
            var securityContext = services.GetRequiredService<SecurityContext>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            EnsureRolesAsync(roleManager).Wait();
            EnsureCategories(securityContext);
            EnsureDepartments(securityContext);
            EnsureProvinces(securityContext);
            EnsureDistricts(securityContext);
            EnsurePersonAsync(securityContext).Wait();
            EnsureUsersAsync(userManager).Wait();
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            AdministratorRole = new IdentityRole(Roles.Administrator);
            PowerUser = new IdentityRole(Roles.PowerUser);
            User = new IdentityRole(Roles.User);
            Instructor= new IdentityRole(Roles.Instructor);
            Enrolled = new IdentityRole(Roles.Enrolled);

            if (!await roleManager.RoleExistsAsync(Roles.Administrator)) { await roleManager.CreateAsync(AdministratorRole); }
            if (!await roleManager.RoleExistsAsync(Roles.PowerUser)) { await roleManager.CreateAsync(PowerUser); }
            if (!await roleManager.RoleExistsAsync(Roles.User)) { await roleManager.CreateAsync(User); }
            if (!await roleManager.RoleExistsAsync(Roles.Instructor)) { await roleManager.CreateAsync(Instructor); }
            if (!await roleManager.RoleExistsAsync(Roles.Enrolled)) { await roleManager.CreateAsync(Enrolled); }

            Claim EditWorkShop = new Claim(SecurityClaimType.GrantAccess, GrantAccess.EditWorkshop);
            Claim DeleteWorkShop = new Claim(SecurityClaimType.GrantAccess, GrantAccess.DeleteWorkshop);
            Claim AddWorkShop = new Claim(SecurityClaimType.GrantAccess, GrantAccess.AddWorkshop);
            Claim EditEnrollment = new Claim(SecurityClaimType.GrantAccess, GrantAccess.EditEnrollment);
            Claim DeleteEnrollment = new Claim(SecurityClaimType.GrantAccess, GrantAccess.DeleteEnrollment);
            Claim AddEnrollment = new Claim(SecurityClaimType.GrantAccess, GrantAccess.AddEnrollment);

            AdministratorRole = await roleManager.FindByNameAsync(Roles.Administrator);

            if (!(await roleManager.GetClaimsAsync(AdministratorRole)).Where(c=>c.Value == EditWorkShop.Value).Any()) { await roleManager.AddClaimAsync(AdministratorRole, EditWorkShop); }
            if (!(await roleManager.GetClaimsAsync(AdministratorRole)).Where(c => c.Value == DeleteWorkShop.Value).Any()) { await roleManager.AddClaimAsync(AdministratorRole, DeleteWorkShop); }
            if (!(await roleManager.GetClaimsAsync(AdministratorRole)).Where(c => c.Value == AddWorkShop.Value).Any()) { await roleManager.AddClaimAsync(AdministratorRole, AddWorkShop); }
            if (!(await roleManager.GetClaimsAsync(AdministratorRole)).Where(c => c.Value == EditEnrollment.Value).Any()) { await roleManager.AddClaimAsync(AdministratorRole, EditEnrollment); }
            if (!(await roleManager.GetClaimsAsync(AdministratorRole)).Where(c => c.Value == DeleteEnrollment.Value).Any()) { await roleManager.AddClaimAsync(AdministratorRole, DeleteEnrollment); }
            if (!(await roleManager.GetClaimsAsync(AdministratorRole)).Where(c => c.Value == AddEnrollment.Value).Any()) { await roleManager.AddClaimAsync(AdministratorRole, AddEnrollment); }

        }
        private static void EnsureCategories(SecurityContext context)
        {
            AWS = new Category { Description = "AWS" };
            QA = new Category { Description = "QA" };
            BD = new Category { Description = "BD" };
            JAVA = new Category { Description = "JAVA" };
            NET = new Category { Description = "NET" };
            Microservices = new Category { Description = "Microservices" };
            Azure = new Category { Description = "Azure" };
            Agile = new Category { Description = "Agile" };
            DevOps = new Category { Description = "DevOps" };
            Architecture = new Category { Description = "Architecture" };

            if (!context.Categories.Where(c => c.Description == AWS.Description).Any()) {context.Categories.Add(AWS); }
            if (!context.Categories.Where(c => c.Description == QA.Description).Any()) { context.Categories.Add(QA); }
            if (!context.Categories.Where(c => c.Description == BD.Description).Any()) { context.Categories.Add(BD); }
            if (!context.Categories.Where(c => c.Description == JAVA.Description).Any()) { context.Categories.Add(JAVA); }
            if (!context.Categories.Where(c => c.Description == NET.Description).Any()) { context.Categories.Add(NET); }
            if (!context.Categories.Where(c => c.Description == Microservices.Description).Any()) { context.Categories.Add(Microservices); }
            if (!context.Categories.Where(c => c.Description == Azure.Description).Any()) { context.Categories.Add(Azure); }
            if (!context.Categories.Where(c => c.Description == Agile.Description).Any()) { context.Categories.Add(Agile); }
            if (!context.Categories.Where(c => c.Description == DevOps.Description).Any()) { context.Categories.Add(DevOps); }
            if (!context.Categories.Where(c => c.Description == Architecture.Description).Any()) { context.Categories.Add(Architecture); }

            context.SaveChanges();
        }
        private static void EnsureDepartments(SecurityContext context)
        {
            Lima = new Department { Description = "Lima" };
            Tumbes = new Department { Description = "Tumbes" };
            Arequipa = new Department { Description = "Arequipa" };
            Ancash = new Department { Description = "Ancash" };
            Ayacucho = new Department { Description = "Ayacucho" };

            if (!context.Departments.Where(d => d.Description == Lima.Description).Any()) { context.Departments.Add(Lima); }
            if (!context.Departments.Where(d => d.Description == Tumbes.Description).Any()) { context.Departments.Add(Tumbes); }
            if (!context.Departments.Where(d => d.Description == Arequipa.Description).Any()) { context.Departments.Add(Arequipa); }
            if (!context.Departments.Where(d => d.Description == Ancash.Description).Any()) { context.Departments.Add(Ancash); }
            if (!context.Departments.Where(d => d.Description == Ayacucho.Description).Any()) { context.Departments.Add(Ayacucho); }

            context.SaveChanges();
        }
        private static void EnsureProvinces(SecurityContext context)
        {
            LimaProvince = new Province { Department = Lima, Description = "Lima" };
            Huaral = new Province { Department = Lima, Description = "Huaral" };
            TumbesProvince = new Province { Department = Tumbes, Description = "Tumbes" };
            Zarumilla = new Province { Department = Tumbes, Description = "Zarumilla" };
            ArequipaProvince = new Province { Department = Arequipa, Description = "Arequipa" };
            Camana = new Province { Department = Arequipa, Description = "Camaná" };
            Huaraz = new Province { Department = Ancash, Description = "Huaraz" };
            Yungay = new Province { Department = Ancash, Description = "Yungay" };
            Huamanga = new Province { Department = Ayacucho, Description = "Huamanga" };
            Sucre = new Province { Department = Ayacucho, Description = "Sucre" };


            if (!context.Provinces.Where(d => d.Description == LimaProvince.Description).Any()) { context.Provinces.Add(LimaProvince); }
            if (!context.Provinces.Where(d => d.Description == Huaral.Description).Any()) { context.Provinces.Add(Huaral); }
            if (!context.Provinces.Where(d => d.Description == TumbesProvince.Description).Any()) { context.Provinces.Add(TumbesProvince); }
            if (!context.Provinces.Where(d => d.Description == Zarumilla.Description).Any()) { context.Provinces.Add(Zarumilla); }
            if (!context.Provinces.Where(d => d.Description == ArequipaProvince.Description).Any()) { context.Provinces.Add(ArequipaProvince); }
            if (!context.Provinces.Where(d => d.Description == Camana.Description).Any()) { context.Provinces.Add(Camana); }
            if (!context.Provinces.Where(d => d.Description == Huaraz.Description).Any()) { context.Provinces.Add(Huaraz); }
            if (!context.Provinces.Where(d => d.Description == Yungay.Description).Any()) { context.Provinces.Add(Yungay); }
            if (!context.Provinces.Where(d => d.Description == Huamanga.Description).Any()) { context.Provinces.Add(Huamanga); }
            if (!context.Provinces.Where(d => d.Description == Sucre.Description).Any()) { context.Provinces.Add(Sucre); }

            context.SaveChanges();
        }
        private static void EnsureDistricts(SecurityContext context)
        {
            LimaDistrict = new District { Province = LimaProvince, Description = "Lima" };
            SanJuandeLurigancho = new District { Province = LimaProvince, Description = "San Juan de Lurigancho" };
            HuaralDistrict = new District { Province = Huaral, Description = "Huaral" };
            Chancay = new District { Province = Huaral, Description = "Chancay" };
            TumbesDistrict = new District { Province = TumbesProvince, Description = "Tumbes" };
            SanJacinto = new District { Province = TumbesProvince, Description = "San Jacinto" };
            ZarumillaDistrict = new District { Province = Zarumilla, Description = "Zarumilla" };
            AguasVerdes = new District { Province = Zarumilla, Description = "Aguas Verdes" };
            ArequipaDistrict = new District { Province = ArequipaProvince, Description = "Arequipa" };
            JoseLuisBustamanteyRivero = new District { Province = ArequipaProvince, Description = "José Luis Bustamante y Rivero" };
            CamanaDistrict = new District { Province = Camana, Description = "Camaná" };
            Ocona = new District { Province = Camana, Description = "Ocoña" };
            HuarazDistrict = new District { Province = Huaraz, Description = "Huaraz" };
            Colcabamba = new District { Province = Huaraz, Description = "Colcabamba" };
            YungayDistrict = new District { Province = Yungay, Description = "Yungay" };
            Cascapara = new District { Province = Yungay, Description = "Cascapara" };
            AcosVinchos = new District { Province = Huamanga, Description = "Acos Vinchos" };
            AndresAvelinoCaceresDorregaray = new District { Province = Huamanga, Description = "Andrés Avelino Cáceres Dorregaray" };
            Querobamba = new District { Province = Sucre, Description = "Querobamba" };
            SantiagodePaucaray = new District { Province = Sucre, Description = "Santiago de Paucaray" };

            if (!context.Districts.Where(d => d.Description == LimaDistrict.Description).Any()) { context.Districts.Add(LimaDistrict); }
            if (!context.Districts.Where(d => d.Description == SanJuandeLurigancho.Description).Any()) { context.Districts.Add(SanJuandeLurigancho); }
            if (!context.Districts.Where(d => d.Description == HuaralDistrict.Description).Any()) { context.Districts.Add(HuaralDistrict); }
            if (!context.Districts.Where(d => d.Description == Chancay.Description).Any()) { context.Districts.Add(Chancay); }
            if (!context.Districts.Where(d => d.Description == TumbesDistrict.Description).Any()) { context.Districts.Add(TumbesDistrict); }
            if (!context.Districts.Where(d => d.Description == SanJacinto.Description).Any()) { context.Districts.Add(SanJacinto); }
            if (!context.Districts.Where(d => d.Description == ZarumillaDistrict.Description).Any()) { context.Districts.Add(ZarumillaDistrict); }
            if (!context.Districts.Where(d => d.Description == AguasVerdes.Description).Any()) { context.Districts.Add(AguasVerdes); }
            if (!context.Districts.Where(d => d.Description == ArequipaDistrict.Description).Any()) { context.Districts.Add(ArequipaDistrict); }
            if (!context.Districts.Where(d => d.Description == JoseLuisBustamanteyRivero.Description).Any()) { context.Districts.Add(JoseLuisBustamanteyRivero); }
            if (!context.Districts.Where(d => d.Description == CamanaDistrict.Description).Any()) { context.Districts.Add(CamanaDistrict); }
            if (!context.Districts.Where(d => d.Description == Ocona.Description).Any()) { context.Districts.Add(Ocona); }
            if (!context.Districts.Where(d => d.Description == HuarazDistrict.Description).Any()) { context.Districts.Add(HuarazDistrict); }
            if (!context.Districts.Where(d => d.Description == Colcabamba.Description).Any()) { context.Districts.Add(Colcabamba); }
            if (!context.Districts.Where(d => d.Description == YungayDistrict.Description).Any()) { context.Districts.Add(YungayDistrict); }
            if (!context.Districts.Where(d => d.Description == Cascapara.Description).Any()) { context.Districts.Add(Cascapara); }
            if (!context.Districts.Where(d => d.Description == AcosVinchos.Description).Any()) { context.Districts.Add(AcosVinchos); }
            if (!context.Districts.Where(d => d.Description == AndresAvelinoCaceresDorregaray.Description).Any()) { context.Districts.Add(AndresAvelinoCaceresDorregaray); }
            if (!context.Districts.Where(d => d.Description == Querobamba.Description).Any()) { context.Districts.Add(Querobamba); }
            if (!context.Districts.Where(d => d.Description == SantiagodePaucaray.Description).Any()) { context.Districts.Add(SantiagodePaucaray); }

            context.SaveChanges();
        }
        private static async Task EnsurePersonAsync(SecurityContext context)
        {
            AWS = context.Categories.Where(c=>c.Description == AWS.Description).FirstOrDefault();
            QA = context.Categories.Where(c => c.Description == QA.Description).FirstOrDefault();
            BD = context.Categories.Where(c => c.Description == BD.Description).FirstOrDefault();
            JAVA = context.Categories.Where(c => c.Description == JAVA.Description).FirstOrDefault();
            NET = context.Categories.Where(c => c.Description == NET.Description).FirstOrDefault();
            Microservices = context.Categories.Where(c => c.Description == Microservices.Description).FirstOrDefault();
            Azure = context.Categories.Where(c => c.Description == Azure.Description).FirstOrDefault();
            Agile = context.Categories.Where(c => c.Description == Agile.Description).FirstOrDefault();
            DevOps = context.Categories.Where(c => c.Description == DevOps.Description).FirstOrDefault();
            Architecture = context.Categories.Where(c => c.Description == Architecture.Description).FirstOrDefault();

            Lima = context.Departments.Where(d => d.Description == Lima.Description).FirstOrDefault();
            Tumbes = context.Departments.Where(d => d.Description == Tumbes.Description).FirstOrDefault();
            Arequipa = context.Departments.Where(d => d.Description == Arequipa.Description).FirstOrDefault();
            Ancash = context.Departments.Where(d => d.Description == Ancash.Description).FirstOrDefault();
            Ayacucho = context.Departments.Where(d => d.Description == Ayacucho.Description).FirstOrDefault();

            LimaProvince = context.Provinces.Where(d => d.Description == LimaProvince.Description).FirstOrDefault();
            Huaral = context.Provinces.Where(d => d.Description == Huaral.Description).FirstOrDefault();
            TumbesProvince = context.Provinces.Where(d => d.Description == TumbesProvince.Description).FirstOrDefault();
            Zarumilla = context.Provinces.Where(d => d.Description == Zarumilla.Description).FirstOrDefault();
            ArequipaProvince = context.Provinces.Where(d => d.Description == ArequipaProvince.Description).FirstOrDefault();
            Camana = context.Provinces.Where(d => d.Description == Camana.Description).FirstOrDefault();
            Huaraz = context.Provinces.Where(d => d.Description == Huaraz.Description).FirstOrDefault();
            Yungay = context.Provinces.Where(d => d.Description == Yungay.Description).FirstOrDefault();
            Huamanga = context.Provinces.Where(d => d.Description == Huamanga.Description).FirstOrDefault();
            Sucre = context.Provinces.Where(d => d.Description == Sucre.Description).FirstOrDefault();

            LimaDistrict = context.Districts.Where(d => d.Description == LimaDistrict.Description).FirstOrDefault();
            SanJuandeLurigancho = context.Districts.Where(d => d.Description == SanJuandeLurigancho.Description).FirstOrDefault();
            HuaralDistrict = context.Districts.Where(d => d.Description == HuaralDistrict.Description).FirstOrDefault();
            Chancay = context.Districts.Where(d => d.Description == Chancay.Description).FirstOrDefault();
            TumbesDistrict = context.Districts.Where(d => d.Description == TumbesDistrict.Description).FirstOrDefault();
            SanJacinto = context.Districts.Where(d => d.Description == SanJacinto.Description).FirstOrDefault();
            ZarumillaDistrict = context.Districts.Where(d => d.Description == ZarumillaDistrict.Description).FirstOrDefault();
            AguasVerdes = context.Districts.Where(d => d.Description == AguasVerdes.Description).FirstOrDefault();
            ArequipaDistrict = context.Districts.Where(d => d.Description == ArequipaDistrict.Description).FirstOrDefault();
            JoseLuisBustamanteyRivero = context.Districts.Where(d => d.Description == JoseLuisBustamanteyRivero.Description).FirstOrDefault();
            CamanaDistrict = context.Districts.Where(d => d.Description == CamanaDistrict.Description).FirstOrDefault();
            Ocona = context.Districts.Where(d => d.Description == Ocona.Description).FirstOrDefault();            
            HuarazDistrict= context.Districts.Where(d => d.Description == HuaralDistrict.Description).FirstOrDefault();            
            Colcabamba = context.Districts.Where(d => d.Description == Colcabamba.Description).FirstOrDefault();
            YungayDistrict = context.Districts.Where(d => d.Description == YungayDistrict.Description).FirstOrDefault();
            Cascapara = context.Districts.Where(d => d.Description == Cascapara.Description).FirstOrDefault();
            AcosVinchos = context.Districts.Where(d => d.Description == AcosVinchos.Description).FirstOrDefault();
            AndresAvelinoCaceresDorregaray = context.Districts.Where(d => d.Description == AndresAvelinoCaceresDorregaray.Description).FirstOrDefault();
            Querobamba = context.Districts.Where(d => d.Description == Querobamba.Description).FirstOrDefault();
            SantiagodePaucaray = context.Districts.Where(d => d.Description == SantiagodePaucaray.Description).FirstOrDefault();

            Administrator = new Person
            {
                Title = "Ing.",
                FirstName = "Erick",
                LastName = "Aróstegui",
                SurName = "Cunza",
                IdentificationNumber = "12345678",
                Phone = "99999999",
                Address = new Address { Department = Lima, Province = LimaProvince, District = SanJuandeLurigancho }
            };

            Bill = new Person
            {
                Title = "Ing.",
                FirstName = "Bill",
                LastName = "Gates",
                SurName = "",
                IdentificationNumber = "87654321",
                Phone = "111111111",
                Address = new Address { Department = Lima, Province = Huaral, District = HuaralDistrict }
            };
            Jeff = new Person
            {
                Title = "Ing.",
                FirstName = "Jeff",
                LastName = "Bezos",
                SurName = "",
                IdentificationNumber = "87654322",
                Phone = "22222222",
                Address = new Address { Department = Tumbes, Province = Zarumilla, District = ZarumillaDistrict }
            };
            Alexander = new Person
            {
                Title = "Ing.",
                FirstName = "Alexander",
                LastName = "Graham",
                SurName = "Bell",
                IdentificationNumber = "87654323",
                Phone = "33333333",
                Address = new Address { Department = Arequipa, Province = Camana, District = CamanaDistrict }
            };
            Edgard = new Person
            {
                Title = "Ing.",
                FirstName = "Edgard",
                LastName = "Frank",
                SurName = "Codd",
                IdentificationNumber = "87654324",
                Phone = "44444444",
                Address = new Address { Department = Ancash, Province = Yungay, District = YungayDistrict }
            };
            James = new Person
            {
                Title = "Ing.",
                FirstName = "James",
                LastName = "Gosling",
                SurName = "",
                IdentificationNumber = "87654325",
                Phone = "555555555",
                Address = new Address { Department = Ayacucho, Province = Sucre, District = Querobamba }
            };

            Igor = new Person
            {
                Title = "Sr.",
                FirstName = "Igor",
                LastName = "Villar",
                SurName = "",
                IdentificationNumber = "11111111",
                Phone = "111111111",
                Address = new Address { Department = Lima, Province = LimaProvince, District = LimaDistrict }
            };
            Zakaria = new Person
            {
                Title = "Sr.",
                FirstName = "Zakaria",
                LastName = "Jerez",
                SurName = "",
                IdentificationNumber = "11111112",
                Phone = "11111112",
                Address = new Address { Department = Lima, Province = Huaral, District = Chancay }
            };
            Dionisio = new Person
            {
                Title = "Sr.",
                FirstName = "Dionisio",
                LastName = "Aragon",
                SurName = "",
                IdentificationNumber = "11111113",
                Phone = "111111113",
                Address = new Address { Department = Tumbes, Province = TumbesProvince, District = SanJacinto }
            };
            Hassan = new Person
            {
                Title = "Sr.",
                FirstName = "Hassan",
                LastName = "Carrillo",
                SurName = "",
                IdentificationNumber = "11111114",
                Phone = "11111114",
                Address = new Address { Department = Tumbes, Province = Zarumilla, District = AguasVerdes }
            };
            Esteban = new Person
            {
                Title = "Sr.",
                FirstName = "Esteban",
                LastName = "Francisco",
                SurName = "Pacheco",
                IdentificationNumber = "11111115",
                Phone = "111111115",
                Address = new Address { Department = Arequipa, Province = ArequipaProvince, District = JoseLuisBustamanteyRivero }
            };
            Aina = new Person
            {
                Title = "Srta.",
                FirstName = "Aina",
                LastName = "Oliver",
                SurName = "",
                IdentificationNumber = "11111116",
                Phone = "111111116",
                Address = new Address { Department = Arequipa, Province = Camana, District = Ocona }
            };
            Jesusa = new Person
            {
                Title = "Srta.",
                FirstName = "Jesusa",
                LastName = "Giraldo",
                SurName = "",
                IdentificationNumber = "11111117",
                Phone = "111111117",
                Address = new Address { Department = Ancash, Province = Huaraz, District = Colcabamba }
            };
            Elisabeth = new Person
            {
                Title = "Srta.",
                FirstName = "Elisabeth",
                LastName = "Pico",
                SurName = "",
                IdentificationNumber = "11111118",
                Phone = "111111118",
                Address = new Address { Department = Ancash, Province = Yungay, District = Cascapara }
            };
            Leticia = new Person
            {
                Title = "Srta.",
                FirstName = "Leticia",
                LastName = "Escudero",
                SurName = "",
                IdentificationNumber = "11111119",
                Phone = "111111119",
                Address = new Address { Department = Ayacucho, Province = Huamanga, District = AndresAvelinoCaceresDorregaray }
            };
            Maite = new Person
            {
                Title = "Srta.",
                FirstName = "Maite",
                LastName = "Riquelme",
                SurName = "",
                IdentificationNumber = "111111120",
                Phone = "111111120",
                Address = new Address { Department = Ayacucho, Province = Sucre, District = SantiagodePaucaray }
            };

            if (!context.People.Where(d => d.FirstName == "Erick").Any()) { context.People.Add(Administrator); }

            if (!context.People.Where(d => d.FirstName == "Bill").Any()) { context.People.Add(Bill); }
            if (!context.People.Where(d => d.FirstName == "Jeff").Any()) { context.People.Add(Jeff); }
            if (!context.People.Where(d => d.FirstName == "Alexander").Any()) { context.People.Add(Alexander); }
            if (!context.People.Where(d => d.FirstName == "Edgard").Any()) { context.People.Add(Edgard); }
            if (!context.People.Where(d => d.FirstName == "James").Any()) { context.People.Add(James); }

            if (!context.People.Where(d => d.FirstName == "Igor").Any()) { context.People.Add(Igor); }
            if (!context.People.Where(d => d.FirstName == "Zakaria").Any()) { context.People.Add(Zakaria); }
            if (!context.People.Where(d => d.FirstName == "Dionisio").Any()) { context.People.Add(Dionisio); }
            if (!context.People.Where(d => d.FirstName == "Hassan").Any()) { context.People.Add(Hassan); }
            if (!context.People.Where(d => d.FirstName == "Esteban").Any()) { context.People.Add(Esteban); }
            if (!context.People.Where(d => d.FirstName == "Aina").Any()) { context.People.Add(Aina); }
            if (!context.People.Where(d => d.FirstName == "Jesusa").Any()) { context.People.Add(Jesusa); }
            if (!context.People.Where(d => d.FirstName == "Leticia").Any()) { context.People.Add(Elisabeth); }
            if (!context.People.Where(d => d.FirstName == "Leticia").Any()) { context.People.Add(Leticia); }
            if (!context.People.Where(d => d.FirstName == "Maite").Any()) { context.People.Add(Maite); }

            await context.SaveChangesAsync();
        }
        private static async Task EnsureUsersAsync(UserManager<ApplicationUser> userManager)
        {
            AdministratorUser = new ApplicationUser { UserName = "Administrator", Email = "admin@todo.local", PersonId = Administrator.PersonId, EmailConfirmed = true };

            BillUser = new ApplicationUser { UserName = "bill", Email = "bill@todo.local", PersonId = Bill.PersonId, EmailConfirmed = true, CategoryId = NET.CategoryId };
            JeffUser = new ApplicationUser { UserName = "jeff", Email = "jeff@todo.local", PersonId = Jeff.PersonId, EmailConfirmed = true, CategoryId = AWS.CategoryId };
            AlexanderUser = new ApplicationUser { UserName = "alexander", Email = "alexander@todo.local", PersonId = Alexander.PersonId, EmailConfirmed = true, CategoryId = QA.CategoryId };
            EdgardUser = new ApplicationUser { UserName = "edgard", Email = "edgard@todo.local", PersonId = Edgard.PersonId, EmailConfirmed = true, CategoryId = BD.CategoryId };
            JamesUser = new ApplicationUser { UserName = "james", Email = "james@todo.local", PersonId = James.PersonId, EmailConfirmed = true, CategoryId = JAVA.CategoryId };

            IgorUser = new ApplicationUser { UserName = "igor", Email = "igor@todo.local", PersonId = Igor.PersonId, EmailConfirmed = true };
            ZakariaUser = new ApplicationUser { UserName = "zakaria", Email = "zakaria@todo.local", PersonId = Zakaria.PersonId, EmailConfirmed = true };
            DionisioUser = new ApplicationUser { UserName = "dionisio", Email = "dionisio@todo.local", PersonId = Dionisio.PersonId, EmailConfirmed = true };
            HassanUser = new ApplicationUser { UserName = "hassan", Email = "hassan@todo.local", PersonId = Hassan.PersonId, EmailConfirmed = true };
            EstebanUser = new ApplicationUser { UserName = "esteban", Email = "esteban@todo.local", PersonId = Esteban.PersonId, EmailConfirmed = true };
            AinaUser = new ApplicationUser { UserName = "aina", Email = "aina@todo.local", PersonId = Aina.PersonId, EmailConfirmed = true };
            JesusaUser = new ApplicationUser { UserName = "jesusa", Email = "jesusa@todo.local", PersonId = Jesusa.PersonId, EmailConfirmed = true };
            ElisabethUser = new ApplicationUser { UserName = "elisabeth", Email = "elisabeth@todo.local", PersonId = Elisabeth.PersonId, EmailConfirmed = true };
            LeticiaUser = new ApplicationUser { UserName = "leticia", Email = "leticia@todo.local", PersonId = Leticia.PersonId, EmailConfirmed = true };
            MaiteUser = new ApplicationUser { UserName = "maite", Email = "maite@todo.local", PersonId = Maite.PersonId, EmailConfirmed = true };

            if (!userManager.Users.Where(x => x.UserName == AdministratorUser.UserName).Any())
            {
                await userManager.CreateAsync(AdministratorUser, "P@ssword1234");
                await userManager.AddToRoleAsync(AdministratorUser, Roles.Administrator);
            }

            if (!userManager.Users.Where(x => x.UserName == BillUser.UserName).Any())
            {
                await userManager.CreateAsync(BillUser, "P@ssword1234");
                await userManager.AddToRoleAsync(BillUser, Roles.Instructor);
            }
            if (!userManager.Users.Where(x => x.UserName == JeffUser.UserName).Any())
            {
                await userManager.CreateAsync(JeffUser, "P@ssword1234");
                await userManager.AddToRoleAsync(JeffUser, Roles.Instructor);
            }
            if (!userManager.Users.Where(x => x.UserName == AlexanderUser.UserName).Any())
            {
                await userManager.CreateAsync(AlexanderUser, "P@ssword1234");
                await userManager.AddToRoleAsync(AlexanderUser, Roles.Instructor);
            }
            if (!userManager.Users.Where(x => x.UserName == EdgardUser.UserName).Any())
            {
                await userManager.CreateAsync(EdgardUser, "P@ssword1234");
                await userManager.AddToRoleAsync(EdgardUser, Roles.Instructor);
            }
            if (!userManager.Users.Where(x => x.UserName == JamesUser.UserName).Any())
            {
                await userManager.CreateAsync(JamesUser, "P@ssword1234");
                await userManager.AddToRoleAsync(JamesUser, Roles.Instructor);
            }

            if (!userManager.Users.Where(x => x.UserName == IgorUser.UserName).Any())
            {
                await userManager.CreateAsync(IgorUser, "P@ssword1234");
                await userManager.AddToRoleAsync(IgorUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == ZakariaUser.UserName).Any())
            {
                await userManager.CreateAsync(ZakariaUser, "P@ssword1234");
                await userManager.AddToRoleAsync(ZakariaUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == DionisioUser.UserName).Any())
            {
                await userManager.CreateAsync(DionisioUser, "P@ssword1234");
                await userManager.AddToRoleAsync(DionisioUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == HassanUser.UserName).Any())
            {
                await userManager.CreateAsync(HassanUser, "P@ssword1234");
                await userManager.AddToRoleAsync(HassanUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == EstebanUser.UserName).Any())
            {
                await userManager.CreateAsync(EstebanUser, "P@ssword1234");
                await userManager.AddToRoleAsync(EstebanUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == AinaUser.UserName).Any())
            {
                await userManager.CreateAsync(AinaUser, "P@ssword1234");
                await userManager.AddToRoleAsync(AinaUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == JesusaUser.UserName).Any())
            {
                await userManager.CreateAsync(JesusaUser, "P@ssword1234");
                await userManager.AddToRoleAsync(JesusaUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == ElisabethUser.UserName).Any())
            {
                await userManager.CreateAsync(ElisabethUser, "P@ssword1234");
                await userManager.AddToRoleAsync(ElisabethUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == LeticiaUser.UserName).Any())
            {
                await userManager.CreateAsync(LeticiaUser, "P@ssword1234");
                await userManager.AddToRoleAsync(LeticiaUser, Roles.Enrolled);
            }
            if (!userManager.Users.Where(x => x.UserName == MaiteUser.UserName).Any())
            {
                await userManager.CreateAsync(MaiteUser, "P@ssword1234");
                await userManager.AddToRoleAsync(MaiteUser, Roles.Enrolled);
            }
        }
    }
}
