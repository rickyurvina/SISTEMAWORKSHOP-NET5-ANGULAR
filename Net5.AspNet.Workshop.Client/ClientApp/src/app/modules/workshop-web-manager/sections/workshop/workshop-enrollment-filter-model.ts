import { Instructor } from "../../../../models/instructor";
import { EnrollmentFilter } from "../../../../services/data/workshop/enrollment-filter";

export class WorkshopEnrollmentFilterModel extends EnrollmentFilter {
  constructor() {
    super();

    this.WorkshopId = 0;
    this.EnrolledId = 0;
  }
  public WorkshopId: number;
  public EnrolledId: number;
}
