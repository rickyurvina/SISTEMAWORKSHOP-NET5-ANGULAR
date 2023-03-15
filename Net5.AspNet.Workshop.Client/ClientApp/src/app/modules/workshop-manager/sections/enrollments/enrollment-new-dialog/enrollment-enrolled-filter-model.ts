import { Workshop } from "../../../../../models/workshop";
import { EnrollmentFilter } from "../../../../../services/data/workshop/enrollment-filter";

export class EnrollmentEnrolledFilterModel extends EnrollmentFilter {
  constructor() {
    super();

    this.EnrolledName = "";
    this.WorkshopId = 0;
    this.Workshop = new Workshop();
    this.EnrolledIdentificationNumber = "";
  }

  public EnrolledName: string;
  public EnrolledIdentificationNumber: string;
  public WorkshopId: number;
  public Workshop: Workshop;
}
