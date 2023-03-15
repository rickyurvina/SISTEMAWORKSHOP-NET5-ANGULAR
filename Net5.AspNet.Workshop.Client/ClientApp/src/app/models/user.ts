import { Address } from "./address";
import { Person } from "./person";
import { Role } from "./role";

export class User extends Person {
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

    this.Id = "";
    this.UserName = "";
    this.Password = "";
    this.Roles = new Array<Role>();    
  }

  public Id: string;
  public UserName: string;
  public Password: string;
  public Roles: Array<Role>;
}
