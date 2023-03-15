import { Department } from "./department";
import { District } from "./district";
import { Province } from "./province";

export class Address {
  constructor() {
    this.AddressId = 0;
    this.DepartmentId = 0;
    this.ProvinceId = 0;
    this.DistrictId = 0;

    this.Department = new Department();
    this.Province = new Province();
    this.District = new District();
  }
  public AddressId: number;
  public DepartmentId: number;
  public ProvinceId: number;
  public DistrictId: number;

  public Department: Department;
  public Province: Province;
  public District: District;
}
