import { Workshop } from "../../../models/workshop";

export class EnrollmentFilter {
  constructor() {
    this.EnrolledName = "";
    this.EnrolledIdentificationNumber = "";
    this.WorshopTitle = "";
    this.EnrollmentStatesIds = new Array<number>();
    this.WorkshopId = 0;
    this.EnrolledId = 0;
    this.Workshop = new Workshop();
  }

  public EnrolledName: string;
  public WorshopTitle: string;
  public EnrollmentStatesIds: Array<number>;
  public StartDate?: Date;
  public EndDate?: Date;

  
  public EnrolledIdentificationNumber: string;
  public EnrolledId: number;
  public WorkshopId: number;
  public Workshop: Workshop;

}
