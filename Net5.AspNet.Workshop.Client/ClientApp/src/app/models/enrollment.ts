import { EnrollmentState } from "./enrollment-state";
import { Enrolled } from "./enrolled";
import { Workshop } from "./workshop";

export class Enrollment {
  constructor() {
    this.EnrollmentId = 0;
    this.EnrolledId = 0;
    this.WorkshopId = 0;
    this.Workshop = new Workshop();
    this.Enrolled = new Enrolled();
    this.EnrollmentDate = new Date();
    this.EnrollmentState = new EnrollmentState();
    this.EnrollmentStateId = 0;
  }

  public EnrollmentId: number;
  public EnrolledId: number;
  public WorkshopId: number;    
  public EnrollmentDate: Date;  
  public EnrollmentStateId: number;

  public Enrolled: Enrolled;
  public Workshop: Workshop;
  public EnrollmentState: EnrollmentState;
}
