import { Time } from "@angular/common";
import { Category } from "./category";
import { FileData } from "./filleData";
import { Instructor } from "./instructor";
import { User } from "./user";
import { WorkshopState } from "./workshop-state";

export class Workshop {
  constructor() {
    this.WorkshopId = 0;
    this.Title = "";
    this.Description = "";
    this.CategoryId = 0;
    this.InstructorId = 0;
    this.StartDate = new Date();
    this.StartTime = { hours: 0, minutes: 0 };
    this.StartTimeString = "";    
    this.Quantity = 0;
    this.WorkshopStateId = 0;
    this.CoverFileDataId = 0;
    this.AgendaFileDataId = 0;
    this.CoverFileData = new FileData();
    this.AgendaFileData = new FileData();
    this.Category = new Category();
    this.Instructor = new Instructor();
    this.WorkshopState = new WorkshopState();
  }

  public WorkshopId: number;
  public Title: string;
  public Description: string;
  public CategoryId: number;
  public InstructorId: number;
  public StartDate: Date;
  public StartTime: Time;
  public StartTimeString: string;
  public Quantity: number;
  public WorkshopStateId: number;
  public CoverFileDataId: number;
  public AgendaFileDataId: number;
  public CoverFileData: FileData;
  public AgendaFileData: FileData;
  public Category: Category;
  public Instructor: Instructor;
  public WorkshopState: WorkshopState;
}
