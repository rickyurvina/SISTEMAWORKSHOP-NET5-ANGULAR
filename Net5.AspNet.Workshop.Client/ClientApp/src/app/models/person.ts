import { Address } from "./address";

export class Person {
  constructor() {
    this.PersonId = 0;
    this.Title = ""
    this.Email = "";
    this.FirstName = "";
    this.LastName = "";
    this.SurName = "";
    this.FullName = "";
    this.IdentificationNumber = "";
    this.Phone = "";
    this.Address = new Address();    
  }
  public PersonId: number;  
  public Email: string;
  public Title: string;  
  public FirstName: string;
  public LastName: string;
  public SurName: string;
  public FullName: string;
  public IdentificationNumber: string;
  public Phone: string;
  public Address: Address;  
}
