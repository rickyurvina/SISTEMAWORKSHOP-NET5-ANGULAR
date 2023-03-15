import { Workshop } from "../../../models/workshop";

export class ChangeEnrollmentStatesFilter {
  constructor() {
    this.EnrollmentIds = new Array<number>();
    this.EnrollmentStateId = 0;    
  }

  public EnrollmentIds: Array<number>;
  public EnrollmentStateId: number;
}
