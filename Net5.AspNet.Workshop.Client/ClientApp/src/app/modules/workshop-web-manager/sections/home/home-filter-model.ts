import { Instructor } from "../../../../models/instructor";
import { WorkshopFilter } from "../../../../services/data/workshop/workshop-filter";

export class HomeFilterModel extends WorkshopFilter {
  constructor() {
    super();

    this.Title = "";
    this.InstructorId = 0;
    this.Instructor = new Instructor();    
  }
  public Title: string;
  public InstructorId: number;
  public Instructor: Instructor;

  public StartDate?: Date;
  public EndDate?: Date;
}
