import { Category } from "./category";
import { Person } from "./person";

export class Instructor extends Person {
  constructor(person?: Person) {    
    super();

    if (person) {
      this.Address = person.Address;
      this.Email = person.Email;
      this.FirstName = person.FirstName;
      this.FullName = person.FullName;
      this.PersonId = person.PersonId;
      this.IdentificationNumber = person.IdentificationNumber;
      this.LastName = person.LastName;
      this.Phone = person.Phone;
      this.SurName = person.SurName;
      this.Title = person.Title;
    }

    this.CategoryId = 0;
    this.Category = new Category();    
  }

  public CategoryId: number;
  public Category: Category;
}
