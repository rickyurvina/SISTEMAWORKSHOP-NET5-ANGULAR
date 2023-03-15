import { Workshop } from "../../../../../models/workshop";
import { EnrolledFilter } from "../../../../../services/data/workshop/enrolled-filter";

export class EnrolledFilterModel extends EnrolledFilter {
  constructor() {
    super();

    this.Name = "";
    this.Workshop = new Workshop();
    this.IdentificationNumber = "";    
  }

  public Name: string;
  public IdentificationNumber: string;
  public Workshop: Workshop;
}
