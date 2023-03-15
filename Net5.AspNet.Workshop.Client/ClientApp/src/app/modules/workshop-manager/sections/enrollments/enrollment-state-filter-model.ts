import { EnrollmentStateFilter } from "../../../../services/data/workshop/enrollment-state-filter";

export class EnrollmentStateFilterModel extends EnrollmentStateFilter {
  constructor() {
    super();
    this.EnrollmentStatesIds = new Array<number>();
  }
  public EnrollmentStatesIds: Array<number>;  
}
