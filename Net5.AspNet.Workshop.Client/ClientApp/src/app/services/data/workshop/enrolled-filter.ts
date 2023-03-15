import { Workshop } from "../../../models/workshop";

export class EnrolledFilter {
  constructor() {    
    this.Name = "";
    this.Workshop = new Workshop();
    this.IdentificationNumber = "";    
  }

  public Name: string;
  public IdentificationNumber: string;
  public Workshop: Workshop;
}
