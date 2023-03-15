using Microsoft.Extensions.DependencyInjection;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data
{
    public static class SeedData
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        static WorkshopState Opened;
        static WorkshopState Cancelled;
        static WorkshopState ByOpening;
        static WorkshopState Concluded;

        static EnrollmentState Enrolled;
        static EnrollmentState Attend;
        static EnrollmentState Canceled;

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

        static FileDatum CoverFileData01;
        static FileDatum AgendaFileData01;
        static FileDatum CoverFileData02;
        static FileDatum AgendaFileData02;
        static FileDatum CoverFileData03;
        static FileDatum AgendaFileData03;
        static FileDatum CoverFileData04;
        static FileDatum AgendaFileData04;
        static FileDatum CoverFileData05;
        static FileDatum AgendaFileData05;
        static FileDatum CoverFileData06;
        static FileDatum AgendaFileData06;
        static FileDatum CoverFileData07;
        static FileDatum AgendaFileData07;
        static FileDatum CoverFileData08;
        static FileDatum AgendaFileData08;
        static FileDatum CoverFileData09;
        static FileDatum AgendaFileData09;
        static FileDatum CoverFileData10;
        static FileDatum AgendaFileData10;

        static Entities.Workshop WorkshopEC2andVPC;
        static Entities.Workshop WorkshopGenerando;
        static Entities.Workshop WorkshopSimplificacion;
        static Entities.Workshop WorkshopProgramacion;
        static Entities.Workshop WorkshopAngularinterceptores;
        static Entities.Workshop WorkshopGestion;
        static Entities.Workshop WorkshopAngularHttp;
        static Entities.Workshop WorkshopAutomatizacion;
        static Entities.Workshop WorkshopAplicaciones;
        static Entities.Workshop WorkshopAzure;

        public static void Initialize(IServiceProvider services)
        {
            var workshopContext = services.GetRequiredService<WorkshopContext>();

            EnsureWorkshopStatesAsync(workshopContext).Wait();
            EnsureEnrollmentStatesAsync(workshopContext).Wait();
            EnsureFilesDataAsync(workshopContext).Wait();
            EnsureWorkshopAsync(workshopContext).Wait();
            EnsureEnrollmentAsync(workshopContext).Wait();
        }

        private static async Task EnsureWorkshopStatesAsync(WorkshopContext context)
        {
            Opened = new WorkshopState { Description = "Opened" };
            Cancelled = new WorkshopState { Description = "Cancelled" };
            ByOpening = new WorkshopState { Description = "By Opening" };
            Concluded = new WorkshopState { Description = "Concluded" };

            if (!context.WorkshopStates.Where(d => d.Description == "Opened").Any()) { context.WorkshopStates.Add(Opened); }
            if (!context.WorkshopStates.Where(d => d.Description == "Cancelled").Any()) { context.WorkshopStates.Add(Cancelled); }
            if (!context.WorkshopStates.Where(d => d.Description == "By Opening").Any()) { context.WorkshopStates.Add(ByOpening); }
            if (!context.WorkshopStates.Where(d => d.Description == "Concluded").Any()) { context.WorkshopStates.Add(Concluded); }

            await context.SaveChangesAsync();
        }
        private static async Task EnsureEnrollmentStatesAsync(WorkshopContext context)
        {
            Enrolled = new EnrollmentState { Description = "Enrolled" };
            Attend = new EnrollmentState { Description = "Attend" };
            Canceled = new EnrollmentState { Description = "Canceled" };

            if (!context.EnrollmentStates.Where(d => d.Description == "Enrolled").Any()) { context.EnrollmentStates.Add(Enrolled); }
            if (!context.EnrollmentStates.Where(d => d.Description == "Attend").Any()) { context.EnrollmentStates.Add(Attend); }
            if (!context.EnrollmentStates.Where(d => d.Description == "Canceled").Any()) { context.EnrollmentStates.Add(Canceled); }

            await context.SaveChangesAsync();
        }

        private static async Task EnsureFilesDataAsync(WorkshopContext context)
        {
            CoverFileData01 = new FileDatum { FileName = "Net 5 - 01.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/images" };
            AgendaFileData01 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 01.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData02 = new FileDatum { FileName = "Net 5 - 02.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData02 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 02.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData03 = new FileDatum { FileName = "Net 5 - 03.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData03 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 03.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData04 = new FileDatum { FileName = "Net 5 - 04.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData04 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 04.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData05 = new FileDatum { FileName = "Net 5 - 05.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData05 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 05.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData06 = new FileDatum { FileName = "Net 5 - 06.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData06 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 06.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData07 = new FileDatum { FileName = "Net 5 - 07.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData07 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 07.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData08 = new FileDatum { FileName = "Net 5 - 08.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData08 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 08.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData09 = new FileDatum { FileName = "Net 5 - 09.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData09 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 09.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };
            CoverFileData10 = new FileDatum { FileName = "Net 5 - 10.png", Size = 330577, Type = "image/png", Extension = "png", Path = "/Images" };
            AgendaFileData10 = new FileDatum { FileName = "TEMARIO_PROGRAMA ASP.NET 5.0 - 10.pdf", Extension = "pdf", Size = 5834211, Type = "application/pdf", Path = "/Documents" };

            if (!context.FileData.Where(d => d.FileName == "Net 5 - 01.png").Any()) { context.FileData.Add(CoverFileData01); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 02.png").Any()) { context.FileData.Add(CoverFileData02); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 03.png").Any()) { context.FileData.Add(CoverFileData03); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 04.png").Any()) { context.FileData.Add(CoverFileData04); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 05.png").Any()) { context.FileData.Add(CoverFileData05); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 06.png").Any()) { context.FileData.Add(CoverFileData06); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 07.png").Any()) { context.FileData.Add(CoverFileData07); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 08.png").Any()) { context.FileData.Add(CoverFileData08); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 09.png").Any()) { context.FileData.Add(CoverFileData09); }
            if (!context.FileData.Where(d => d.FileName == "Net 5 - 10.png").Any()) { context.FileData.Add(CoverFileData10); }

            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 01.pdf").Any()) { context.FileData.Add(AgendaFileData01); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 02.pdf").Any()) { context.FileData.Add(AgendaFileData02); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 03.pdf").Any()) { context.FileData.Add(AgendaFileData03); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 04.pdf").Any()) { context.FileData.Add(AgendaFileData04); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 05.pdf").Any()) { context.FileData.Add(AgendaFileData05); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 06.pdf").Any()) { context.FileData.Add(AgendaFileData06); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 07.pdf").Any()) { context.FileData.Add(AgendaFileData07); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 08.pdf").Any()) { context.FileData.Add(AgendaFileData08); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 09.pdf").Any()) { context.FileData.Add(AgendaFileData09); }
            if (!context.FileData.Where(d => d.FileName == "TEMARIO_PROGRAMA ASP.NET 5.0 - 10.pdf").Any()) { context.FileData.Add(AgendaFileData10); }

            await context.SaveChangesAsync();
        }

        private static async Task EnsureWorkshopAsync(WorkshopContext context)
        {
            Bill = context.People.Where(p => p.FirstName == "Bill").FirstOrDefault();
            Jeff = context.People.Where(p => p.FirstName == "Jeff").FirstOrDefault();
            Alexander = context.People.Where(p => p.FirstName == "Alexander").FirstOrDefault();
            Edgard = context.People.Where(p => p.FirstName == "Edgard").FirstOrDefault();
            James = context.People.Where(p => p.FirstName == "James").FirstOrDefault();

            AWS = context.Categories.Where(c => c.Description == "AWS").FirstOrDefault();
            QA = context.Categories.Where(c => c.Description == "QA").FirstOrDefault();
            BD = context.Categories.Where(c => c.Description == "BD").FirstOrDefault();
            JAVA = context.Categories.Where(c => c.Description == "JAVA").FirstOrDefault();
            NET = context.Categories.Where(c => c.Description == "NET").FirstOrDefault();
            Microservices = context.Categories.Where(c => c.Description == "Microservices").FirstOrDefault();
            Azure = context.Categories.Where(c => c.Description == "Azure").FirstOrDefault();
            Agile = context.Categories.Where(c => c.Description == "Agile").FirstOrDefault();
            DevOps = context.Categories.Where(c => c.Description == "DevOps").FirstOrDefault();
            Architecture = context.Categories.Where(c => c.Description == "Architecture").FirstOrDefault();

            Opened = context.WorkshopStates.Where(c => c.Description == Opened.Description).FirstOrDefault();
            Concluded = context.WorkshopStates.Where(c => c.Description == Concluded.Description).FirstOrDefault();
            ByOpening = context.WorkshopStates.Where(c => c.Description == ByOpening.Description).FirstOrDefault();
            Cancelled = context.WorkshopStates.Where(c => c.Description == Cancelled.Description).FirstOrDefault();

            CoverFileData01 = context.FileData.Where(c => c.FileName == CoverFileData01.FileName).FirstOrDefault();
            CoverFileData02 = context.FileData.Where(c => c.FileName == CoverFileData02.FileName).FirstOrDefault();
            CoverFileData03 = context.FileData.Where(c => c.FileName == CoverFileData03.FileName).FirstOrDefault();
            CoverFileData04 = context.FileData.Where(c => c.FileName == CoverFileData04.FileName).FirstOrDefault();
            CoverFileData05 = context.FileData.Where(c => c.FileName == CoverFileData05.FileName).FirstOrDefault();
            CoverFileData06 = context.FileData.Where(c => c.FileName == CoverFileData06.FileName).FirstOrDefault();
            CoverFileData07 = context.FileData.Where(c => c.FileName == CoverFileData07.FileName).FirstOrDefault();
            CoverFileData08 = context.FileData.Where(c => c.FileName == CoverFileData08.FileName).FirstOrDefault();
            CoverFileData09 = context.FileData.Where(c => c.FileName == CoverFileData09.FileName).FirstOrDefault();
            CoverFileData10 = context.FileData.Where(c => c.FileName == CoverFileData10.FileName).FirstOrDefault();

            AgendaFileData01 = context.FileData.Where(c => c.FileName == AgendaFileData01.FileName).FirstOrDefault();
            AgendaFileData02 = context.FileData.Where(c => c.FileName == AgendaFileData02.FileName).FirstOrDefault();
            AgendaFileData03 = context.FileData.Where(c => c.FileName == AgendaFileData03.FileName).FirstOrDefault();
            AgendaFileData04 = context.FileData.Where(c => c.FileName == AgendaFileData04.FileName).FirstOrDefault();
            AgendaFileData05 = context.FileData.Where(c => c.FileName == AgendaFileData05.FileName).FirstOrDefault();
            AgendaFileData06 = context.FileData.Where(c => c.FileName == AgendaFileData06.FileName).FirstOrDefault();
            AgendaFileData07 = context.FileData.Where(c => c.FileName == AgendaFileData07.FileName).FirstOrDefault();
            AgendaFileData08 = context.FileData.Where(c => c.FileName == AgendaFileData08.FileName).FirstOrDefault();
            AgendaFileData09 = context.FileData.Where(c => c.FileName == AgendaFileData09.FileName).FirstOrDefault();
            AgendaFileData10 = context.FileData.Where(c => c.FileName == AgendaFileData10.FileName).FirstOrDefault();

            WorkshopEC2andVPC = new Entities.Workshop
            {
                WorkshopStateId = Opened.WorkshopStateId,
                InstructorPersonId = Bill.PersonId,
                Title = "EC2 and VPC network and infrastructure management",
                Description = "EC2 and VPC network and infrastructure management",
                CategoryId = AWS.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData01.FileDataId,
                AgendaFileDataId = AgendaFileData01.FileDataId,
                CoverFileData = CoverFileData01,
                AgendaFileData = AgendaFileData01,
                WorkshopState = Opened,
                InstructorPerson = Bill,
                Category = AWS
            };
            WorkshopGenerando = new Entities.Workshop
            {
                WorkshopStateId = Cancelled.WorkshopStateId,
                InstructorPersonId = Jeff.PersonId,
                Title = "Generando reportes con 'Extend Reports",
                Description = "Generando reportes con 'Extend Reports",
                CategoryId = QA.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData02.FileDataId,
                AgendaFileDataId = AgendaFileData02.FileDataId,
                CoverFileData = CoverFileData02,
                AgendaFileData = AgendaFileData02,
                WorkshopState = Cancelled,
                InstructorPerson = Jeff,
                Category = QA
            };
            WorkshopSimplificacion = new Entities.Workshop
            {
                WorkshopStateId = ByOpening.WorkshopStateId,
                InstructorPersonId = Alexander.PersonId,
                Title = "Simplificación de tareas de administración en Oracle 12c, 18c y 19c",
                Description = "Simplificación de tareas de administración en Oracle 12c, 18c y 19c",
                CategoryId = BD.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData03.FileDataId,
                AgendaFileDataId = AgendaFileData03.FileDataId,
                CoverFileData = CoverFileData03,
                AgendaFileData = AgendaFileData03,
                WorkshopState = ByOpening,
                InstructorPerson = Alexander,
                Category = BD,
            };
            WorkshopProgramacion = new Entities.Workshop
            {
                WorkshopStateId = Concluded.WorkshopStateId,
                InstructorPersonId = Edgard.PersonId,
                Title = "Programacion funcional en Java",
                Description = "Programacion funcional en Java",
                CategoryId = JAVA.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData04.FileDataId,
                AgendaFileDataId = AgendaFileData04.FileDataId,
                CoverFileData = CoverFileData04,
                AgendaFileData = AgendaFileData04,
                WorkshopState = Concluded,
                InstructorPerson = Edgard,
                Category = JAVA
            };
            WorkshopAngularinterceptores = new Entities.Workshop
            {
                WorkshopStateId = Opened.WorkshopStateId,
                InstructorPersonId = James.PersonId,
                Title = "Angular interceptores",
                Description = "Angular interceptores",
                CategoryId = NET.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData05.FileDataId,
                AgendaFileDataId = AgendaFileData05.FileDataId,
                CoverFileData = CoverFileData05,
                AgendaFileData = AgendaFileData05,
                WorkshopState = Opened,
                InstructorPerson = James,
                Category = NET
            };
            WorkshopGestion = new Entities.Workshop
            {
                WorkshopStateId = Opened.WorkshopStateId,
                InstructorPersonId = Bill.PersonId,
                Title = "Gestión de identidad y Accesos y creación de Buckets con  IAM y S3",
                Description = "Gestión de identidad y Accesos y creación de Buckets con  IAM y S3",
                CategoryId = AWS.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData06.FileDataId,
                AgendaFileDataId = AgendaFileData06.FileDataId,
                CoverFileData = CoverFileData06,
                AgendaFileData = AgendaFileData06,
                WorkshopState = Opened,
                InstructorPerson = Bill,
                Category = AWS
            };
            WorkshopAngularHttp = new Entities.Workshop
            {
                WorkshopStateId = Cancelled.WorkshopStateId,
                InstructorPersonId = Jeff.PersonId,
                Title = "Angular Http",
                Description = "Angular Http",
                CategoryId = NET.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData07.FileDataId,
                AgendaFileDataId = AgendaFileData07.FileDataId,
                CoverFileData = CoverFileData07,
                AgendaFileData = AgendaFileData07,
                WorkshopState = Cancelled,
                InstructorPerson = Jeff,
                Category = NET
            };
            WorkshopAutomatizacion = new Entities.Workshop
            {
                WorkshopStateId = ByOpening.WorkshopStateId,
                InstructorPersonId = Alexander.PersonId,
                Title = "Automatización de pruebas en aplicaciones web con selenium",
                Description = "Automatización de pruebas en aplicaciones web con selenium",
                CategoryId = QA.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData08.FileDataId,
                AgendaFileDataId = AgendaFileData08.FileDataId,
                CoverFileData = CoverFileData08,
                AgendaFileData = AgendaFileData08,
                WorkshopState = ByOpening,
                InstructorPerson = Alexander,
                Category = QA
            };
            WorkshopAplicaciones = new Entities.Workshop
            {
                WorkshopStateId = Concluded.WorkshopStateId,
                InstructorPersonId = Edgard.PersonId,
                Title = "Aplicaciones con Spring Security",
                Description = "Aplicaciones con Spring Security",
                CategoryId = JAVA.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData09.FileDataId,
                AgendaFileDataId = AgendaFileData09.FileDataId,
                CoverFileData = CoverFileData09,
                AgendaFileData = AgendaFileData09,
                WorkshopState = Concluded,
                InstructorPerson = Edgard,
                Category = JAVA
            };
            WorkshopAzure = new Entities.Workshop
            {
                WorkshopStateId = Concluded.WorkshopStateId,
                InstructorPersonId = James.PersonId,
                Title = "Azure Spring Boot",
                Description = "Azure Spring Boot",
                CategoryId = Azure.CategoryId,
                StartDate = DateTime.Now,
                StartTime = DateTime.Now.TimeOfDay,
                CoverFileDataId = CoverFileData10.FileDataId,
                AgendaFileDataId = AgendaFileData10.FileDataId,
                CoverFileData = CoverFileData10,
                AgendaFileData = AgendaFileData10,
                WorkshopState = Concluded,
                InstructorPerson = James,
                Category = Azure
            };

            if (!context.Workshops.Where(d => d.Title == WorkshopEC2andVPC.Title).Any()) { context.Workshops.Add(WorkshopEC2andVPC); }
            if (!context.Workshops.Where(d => d.Title == WorkshopGenerando.Title).Any()) { context.Workshops.Add(WorkshopGenerando); }
            if (!context.Workshops.Where(d => d.Title == WorkshopSimplificacion.Title).Any()) { context.Workshops.Add(WorkshopSimplificacion); }
            if (!context.Workshops.Where(d => d.Title == WorkshopProgramacion.Title).Any()) { context.Workshops.Add(WorkshopProgramacion); }
            if (!context.Workshops.Where(d => d.Title == WorkshopAngularinterceptores.Title).Any()) { context.Workshops.Add(WorkshopAngularinterceptores); }
            if (!context.Workshops.Where(d => d.Title == WorkshopGestion.Title).Any()) { context.Workshops.Add(WorkshopGestion); }
            if (!context.Workshops.Where(d => d.Title == WorkshopAngularHttp.Title).Any()) { context.Workshops.Add(WorkshopAngularHttp); }
            if (!context.Workshops.Where(d => d.Title == WorkshopAutomatizacion.Title).Any()) { context.Workshops.Add(WorkshopAutomatizacion); }
            if (!context.Workshops.Where(d => d.Title == WorkshopAplicaciones.Title).Any()) { context.Workshops.Add(WorkshopAplicaciones); }
            if (!context.Workshops.Where(d => d.Title == WorkshopAzure.Title).Any()) { context.Workshops.Add(WorkshopAzure); }

            await context.SaveChangesAsync();
        }

        private static async Task EnsureEnrollmentAsync(WorkshopContext context)
        {
            Igor = context.People.Where(p => p.FirstName == "Igor").FirstOrDefault();
            Zakaria = context.People.Where(p => p.FirstName == "Zakaria").FirstOrDefault();
            Dionisio = context.People.Where(p => p.FirstName == "Dionisio").FirstOrDefault();
            Hassan = context.People.Where(p => p.FirstName == "Hassan").FirstOrDefault();
            Esteban = context.People.Where(p => p.FirstName == "Esteban").FirstOrDefault();
            Aina = context.People.Where(p => p.FirstName == "Aina").FirstOrDefault();
            Jesusa = context.People.Where(p => p.FirstName == "Jesusa").FirstOrDefault();
            Elisabeth = context.People.Where(p => p.FirstName == "Elisabeth").FirstOrDefault();
            Leticia = context.People.Where(p => p.FirstName == "Leticia").FirstOrDefault();
            Maite = context.People.Where(p => p.FirstName == "Maite").FirstOrDefault();

            Enrolled = context.EnrollmentStates.Where(c => c.Description == Enrolled.Description).FirstOrDefault();
            Attend = context.EnrollmentStates.Where(c => c.Description == Attend.Description).FirstOrDefault();
            Canceled = context.EnrollmentStates.Where(c => c.Description == Canceled.Description).FirstOrDefault();

            WorkshopEC2andVPC = context.Workshops.Where(w => w.Title == WorkshopEC2andVPC.Title).FirstOrDefault();
            WorkshopGenerando = context.Workshops.Where(w => w.Title == WorkshopGenerando.Title).FirstOrDefault();
            WorkshopSimplificacion = context.Workshops.Where(w => w.Title == WorkshopSimplificacion.Title).FirstOrDefault();
            WorkshopProgramacion = context.Workshops.Where(w => w.Title == WorkshopProgramacion.Title).FirstOrDefault();
            WorkshopAngularinterceptores = context.Workshops.Where(w => w.Title == WorkshopAngularinterceptores.Title).FirstOrDefault();
            WorkshopGestion = context.Workshops.Where(w => w.Title == WorkshopGestion.Title).FirstOrDefault();
            WorkshopAngularHttp = context.Workshops.Where(w => w.Title == WorkshopAngularHttp.Title).FirstOrDefault();
            WorkshopAutomatizacion = context.Workshops.Where(w => w.Title == WorkshopAutomatizacion.Title).FirstOrDefault();
            WorkshopAplicaciones = context.Workshops.Where(w => w.Title == WorkshopAplicaciones.Title).FirstOrDefault();
            WorkshopAzure = context.Workshops.Where(w => w.Title == WorkshopAzure.Title).FirstOrDefault();

            Enrollment enrollmentEC2andVPC = new Enrollment
            {
                EnrolledPersonId = Igor.PersonId,
                WorkshopId = WorkshopEC2andVPC.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Enrolled.EnrollmentStateId
            };
            Enrollment enrollmentGenerando = new Enrollment
            {
                EnrolledPersonId = Zakaria.PersonId,
                WorkshopId = WorkshopGenerando.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Attend.EnrollmentStateId
            };
            Enrollment enrollmentSimplificacion = new Enrollment
            {
                EnrolledPersonId = Dionisio.PersonId,
                WorkshopId = WorkshopSimplificacion.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Canceled.EnrollmentStateId
            };
            Enrollment enrollmentProgramacion = new Enrollment
            {
                EnrolledPersonId = Hassan.PersonId,
                WorkshopId = WorkshopProgramacion.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Enrolled.EnrollmentStateId
            };
            Enrollment enrollmentAngularinterceptores = new Enrollment
            {
                EnrolledPersonId = Esteban.PersonId,
                WorkshopId = WorkshopAngularinterceptores.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Attend.EnrollmentStateId
            };
            Enrollment enrollmentGestion = new Enrollment
            {
                EnrolledPersonId = Aina.PersonId,
                WorkshopId = WorkshopGestion.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Canceled.EnrollmentStateId
            };
            Enrollment enrollmentAngularHttp = new Enrollment
            {
                EnrolledPersonId = Jesusa.PersonId,
                WorkshopId = WorkshopAngularHttp.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Enrolled.EnrollmentStateId
            };
            Enrollment enrollmentAutomatizacion = new Enrollment
            {
                EnrolledPersonId = Elisabeth.PersonId,
                WorkshopId = WorkshopAutomatizacion.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Attend.EnrollmentStateId
            };
            Enrollment enrollmentAplicaciones = new Enrollment
            {
                EnrolledPersonId = Leticia.PersonId,
                WorkshopId = WorkshopAplicaciones.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Canceled.EnrollmentStateId
            };
            Enrollment enrollmentAzure = new Enrollment
            {
                EnrolledPersonId = Maite.PersonId,
                WorkshopId = WorkshopAzure.WorkshopId,
                EnrollmentDate = DateTime.Now,
                EnrollmentStateId = Enrolled.EnrollmentStateId
            };

            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopEC2andVPC.WorkshopId).Any()) { context.Enrollments.Add(enrollmentEC2andVPC); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopGenerando.WorkshopId).Any()) { context.Enrollments.Add(enrollmentGenerando); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopSimplificacion.WorkshopId).Any()) { context.Enrollments.Add(enrollmentSimplificacion); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopProgramacion.WorkshopId).Any()) { context.Enrollments.Add(enrollmentProgramacion); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopAngularinterceptores.WorkshopId).Any()) { context.Enrollments.Add(enrollmentAngularinterceptores); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopGestion.WorkshopId).Any()) { context.Enrollments.Add(enrollmentGestion); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopAngularHttp.WorkshopId).Any()) { context.Enrollments.Add(enrollmentAngularHttp); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopAutomatizacion.WorkshopId).Any()) { context.Enrollments.Add(enrollmentAutomatizacion); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopAplicaciones.WorkshopId).Any()) { context.Enrollments.Add(enrollmentAplicaciones); }
            if (!context.Enrollments.Where(e => e.WorkshopId == WorkshopAzure.WorkshopId).Any()) { context.Enrollments.Add(enrollmentAzure); }

            await context.SaveChangesAsync();
        }

    }
}
