import { InstructorFilter } from "../../../../../services/data/workshop/instructor-filter";

export class InstructorsFilterModel extends InstructorFilter {
  constructor() {
    super();

    this.Name = "";
    this.CategoriesIds = new Array<number>();
    this.IdentificationNumber = "";
    
  }
  public Name: string;  
  public CategoriesIds: Array<number>;
  public IdentificationNumber: string;
}
