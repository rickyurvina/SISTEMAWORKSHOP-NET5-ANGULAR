using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class WorkshopDto
    {
        public int WorkshopId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public string StartTimeString { get; set; }
        public int Quantity { get; set; }
        public int WorkshopStateId { get; set; }
        public int CoverFileDataId { get; set; }
        public int AgendaFileDataId { get; set; }
        public virtual FileDatumDto AgendaFileData { get; set; }
        public virtual FileDatumDto CoverFileData { get; set; }        
        public virtual CategoryDto Category { get; set; }        
        public virtual InstructorDto Instructor { get; set; }
        public virtual WorkshopStateDto WorkshopState { get; set; }
    }
}
