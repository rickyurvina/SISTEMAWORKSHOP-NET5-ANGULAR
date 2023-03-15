import { Instructor } from "../../../models/instructor";

export class WorkshopFilter {
  constructor() {    
    this.Title = "";
    this.CategoriesIds = new Array<number>();
    this.WorkshopStatesIds = new Array<number>();
    this.InstructorId = 0;

    this.Instructor = new Instructor(); 
  }
  public Title: string;
  public CategoriesIds: Array<number>;
  public WorkshopStatesIds: Array<number>;
  public InstructorId: number;

  public Instructor: Instructor;
  public StartDate?: Date;
  public EndDate?: Date;
}
