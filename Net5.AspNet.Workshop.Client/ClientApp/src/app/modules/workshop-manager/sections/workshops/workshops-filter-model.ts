import { WorkshopFilter } from "../../../../services/data/workshop/workshop-filter";

export class WorkshopsFilterModel extends WorkshopFilter {
  constructor() {
    super();

    this.Title = "";
    this.CategoriesIds = new Array<number>();
    this.WorkshopStatesIds = new Array<number>();
  }
  public Title: string;  
  public CategoriesIds: Array<number>;
  public WorkshopStatesIds: Array<number>;
}
