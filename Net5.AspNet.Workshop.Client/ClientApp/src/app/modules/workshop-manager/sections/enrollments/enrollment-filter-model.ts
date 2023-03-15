import { EnrollmentFilter } from "../../../../services/data/workshop/enrollment-filter";

export class EnrollmentFilterModel extends EnrollmentFilter {
  constructor() {
    super();

    this.EnrolledName = "";
    this.WorshopTitle = "";
    this.EnrollmentStatesIds = new Array<number>();
  }
  public EnrolledName: string;
  public WorshopTitle: string;
  public EnrollmentStatesIds: Array<number>;
  public StartDate?: Date;
  public EndDate?: Date;
}
