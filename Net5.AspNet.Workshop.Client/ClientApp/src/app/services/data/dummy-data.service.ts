import { Injectable } from '@angular/core';
import { Address } from '../../models/address';
import { Category } from '../../models/category';
import { Department } from '../../models/department';
import { District } from '../../models/district';
import { Enrolled } from '../../models/enrolled';
import { Enrollment } from '../../models/enrollment';
import { EnrollmentState } from '../../models/enrollment-state';
import { Instructor } from '../../models/instructor';
import { Person } from '../../models/person';
import { Province } from '../../models/province';
import { Role } from '../../models/role';
import { User } from '../../models/user';
import { Workshop } from '../../models/workshop';
import { WorkshopState } from '../../models/workshop-state';
import { DummyImagesService } from './dummy-images.service';

@Injectable({
  providedIn: 'root'
})
export class DummyDataService {

  public Roles = new Array<Role>();
  public Categories = new Array<Category>();
  public WorkshopStates = new Array<WorkshopState>();
  public Departments = new Array<Department>();
  public Provinces = new Array<Province>();
  public Districts = new Array<District>();
  public Addresses = new Array<Address>();
  public Users = new Array<User>();
  public Instructors = new Array<Instructor>();
  public Workshops = new Array<Workshop>();
  public Enrollees = new Array<Enrolled>();
  public EnrollmentStates = new Array<EnrollmentState>();
  public Enrollments = new Array<Enrollment>();

  constructor(
    private _dummyImagesService: DummyImagesService
  ) {
    this.initRoles();
    this.initCategories();
    this.initWorkshopStates();
    this.initDepartments();
    this.initProvinces();
    this.initDistricts();
    this.initAddresses();
    this.initUser();
    this.initInstructors();
    this.initWorkshops();
    this.initEnrollmentStates();
    this.initEnrollees();
    this.initEnrollments();
  }

  private initRoles() {
    this.Roles.push({ Id: "a7edccfc-446b-4937-aec4-a1402ca39950", Name: "Administrator", NormalizedName: "ADMINISTRATOR" });
    this.Roles.push({ Id: "f05233ff-46e0-4b92-82b7-8791503c0027", Name: "Instructor", NormalizedName: "INSTRUCTOR" });
    this.Roles.push({ Id: "cdfb2b78-8721-4951-b31d-e0f1631ad6c3", Name: "Student", NormalizedName: "STUDENT" });
    this.Roles.push({ Id: "e0b30fd7-3583-411b-ab8d-b95bbc7a5dbe", Name: "User", NormalizedName: "USER" });
    this.Roles.push({ Id: "c4fd6875-19cc-4dcd-a9ba-a902fb740577", Name: "PowerUser", NormalizedName: "POWERUSER" });
  }

  private initCategories() {
    this.Categories.push({ CategoryId: 1, Description: "AWS" });
    this.Categories.push({ CategoryId: 2, Description: "QA" });
    this.Categories.push({ CategoryId: 3, Description: "BD" });
    this.Categories.push({ CategoryId: 4, Description: "JAVA" });
    this.Categories.push({ CategoryId: 5, Description: "NET" });
    this.Categories.push({ CategoryId: 6, Description: "Microservices" });
    this.Categories.push({ CategoryId: 7, Description: "Azure" });
    this.Categories.push({ CategoryId: 8, Description: "Agile" });
    this.Categories.push({ CategoryId: 9, Description: "DevOps" });
    this.Categories.push({ CategoryId: 10, Description: "Architecture" });
  }

  private initWorkshopStates() {
    this.WorkshopStates.push({ WorkshopStateId: 1, Description: "Opened" });
    this.WorkshopStates.push({ WorkshopStateId: 2, Description: "Cancelled" });
    this.WorkshopStates.push({ WorkshopStateId: 3, Description: "By Opening" });
    this.WorkshopStates.push({ WorkshopStateId: 4, Description: "Concluded" });
  }

  private initDepartments() {
    this.Departments.push({ DepartmentId: 1, Description: "Lima" });
    this.Departments.push({ DepartmentId: 2, Description: "Tumbes" });
    this.Departments.push({ DepartmentId: 3, Description: "Arequipa" });
    this.Departments.push({ DepartmentId: 4, Description: "Ancash" });
    this.Departments.push({ DepartmentId: 5, Description: "Ayacucho" });
  }

  private initProvinces() {
    this.Provinces.push({ DepartmentId: 1, ProvinceId: 1, Description: "Lima" });
    this.Provinces.push({ DepartmentId: 1, ProvinceId: 2, Description: "Huaral" });
    this.Provinces.push({ DepartmentId: 2, ProvinceId: 3, Description: "Tumbes" });
    this.Provinces.push({ DepartmentId: 2, ProvinceId: 4, Description: "Zarumilla" });
    this.Provinces.push({ DepartmentId: 3, ProvinceId: 5, Description: "Arequipa" });
    this.Provinces.push({ DepartmentId: 3, ProvinceId: 6, Description: "Camaná" });
    this.Provinces.push({ DepartmentId: 4, ProvinceId: 7, Description: "Huaraz" });
    this.Provinces.push({ DepartmentId: 4, ProvinceId: 8, Description: "Yungay" });
    this.Provinces.push({ DepartmentId: 5, ProvinceId: 9, Description: "Huamanga" });
    this.Provinces.push({ DepartmentId: 5, ProvinceId: 10, Description: "Sucre" });    
  }

  private initDistricts() {
    this.Districts.push({ ProvinceId: 1, DistrictId: 1, Description: "Lima" });
    this.Districts.push({ ProvinceId: 1, DistrictId: 2, Description: "San Juan de Lurigancho" });
    this.Districts.push({ ProvinceId: 2, DistrictId: 3, Description: "Huaral" });
    this.Districts.push({ ProvinceId: 2, DistrictId: 4, Description: "Chancay" });
    this.Districts.push({ ProvinceId: 3, DistrictId: 5, Description: "Tumbes" });
    this.Districts.push({ ProvinceId: 3, DistrictId: 6, Description: "San Jacinto" });
    this.Districts.push({ ProvinceId: 4, DistrictId: 7, Description: "Zarumilla" });
    this.Districts.push({ ProvinceId: 4, DistrictId: 8, Description: "Aguas Verdes" });
    this.Districts.push({ ProvinceId: 5, DistrictId: 9, Description: "Arequipa" });
    this.Districts.push({ ProvinceId: 5, DistrictId: 10, Description: "José Luis Bustamante y Rivero" });
    this.Districts.push({ ProvinceId: 6, DistrictId: 11, Description: "Camaná" });
    this.Districts.push({ ProvinceId: 6, DistrictId: 12, Description: "Ocoña" });
    this.Districts.push({ ProvinceId: 7, DistrictId: 13, Description: "Huaraz" });
    this.Districts.push({ ProvinceId: 7, DistrictId: 14, Description: "Colcabamba" });
    this.Districts.push({ ProvinceId: 8, DistrictId: 15, Description: "Yungay" });
    this.Districts.push({ ProvinceId: 8, DistrictId: 16, Description: "Cascapara" });
    this.Districts.push({ ProvinceId: 9, DistrictId: 17, Description: "Acos Vinchos" });
    this.Districts.push({ ProvinceId: 9, DistrictId: 18, Description: "Andrés Avelino Cáceres Dorregaray" });
    this.Districts.push({ ProvinceId: 10, DistrictId: 19, Description: "Querobamba" });
    this.Districts.push({ ProvinceId: 10, DistrictId: 20, Description: "Santiago de Paucaray" });
  }

  private initAddresses() {
    this.Addresses.push({ AddressId: 1, DepartmentId: 1, ProvinceId: 1, DistrictId: 1, Department: this.Departments[0], Province: this.Provinces[0], District: this.Districts[0] });
    this.Addresses.push({ AddressId: 2, DepartmentId: 2, ProvinceId: 3, DistrictId: 5, Department: this.Departments[1], Province: this.Provinces[2], District: this.Districts[4] });
    this.Addresses.push({ AddressId: 3, DepartmentId: 3, ProvinceId: 5, DistrictId: 9, Department: this.Departments[2], Province: this.Provinces[4], District: this.Districts[8] });
    this.Addresses.push({ AddressId: 4, DepartmentId: 4, ProvinceId: 7, DistrictId: 13, Department: this.Departments[3], Province: this.Provinces[6], District: this.Districts[12] });
    this.Addresses.push({ AddressId: 5, DepartmentId: 5, ProvinceId: 9, DistrictId: 17, Department: this.Departments[4], Province: this.Provinces[8], District: this.Districts[16] });

    this.Addresses.push({ AddressId: 6, DepartmentId: 1, ProvinceId: 2, DistrictId: 3, Department: this.Departments[0], Province: this.Provinces[1], District: this.Districts[2] });
    this.Addresses.push({ AddressId: 7, DepartmentId: 2, ProvinceId: 4, DistrictId: 7, Department: this.Departments[1], Province: this.Provinces[3], District: this.Districts[6] });
    this.Addresses.push({ AddressId: 8, DepartmentId: 3, ProvinceId: 6, DistrictId: 11, Department: this.Departments[2], Province: this.Provinces[5], District: this.Districts[10] });
    this.Addresses.push({ AddressId: 9, DepartmentId: 4, ProvinceId: 8, DistrictId: 15, Department: this.Departments[3], Province: this.Provinces[7], District: this.Districts[14] });
    this.Addresses.push({ AddressId: 10, DepartmentId: 5, ProvinceId: 10, DistrictId: 19, Department: this.Departments[4], Province: this.Provinces[9], District: this.Districts[18] });

    this.Addresses.push({ AddressId: 11, DepartmentId: 1, ProvinceId: 1, DistrictId: 2, Department: this.Departments[0], Province: this.Provinces[0], District: this.Districts[1] });
    this.Addresses.push({ AddressId: 12, DepartmentId: 1, ProvinceId: 2, DistrictId: 4, Department: this.Departments[0], Province: this.Provinces[1], District: this.Districts[3] });
    this.Addresses.push({ AddressId: 13, DepartmentId: 2, ProvinceId: 3, DistrictId: 6, Department: this.Departments[1], Province: this.Provinces[2], District: this.Districts[5] });
    this.Addresses.push({ AddressId: 14, DepartmentId: 2, ProvinceId: 4, DistrictId: 8, Department: this.Departments[1], Province: this.Provinces[3], District: this.Districts[7] });
    this.Addresses.push({ AddressId: 15, DepartmentId: 3, ProvinceId: 5, DistrictId: 10, Department: this.Departments[2], Province: this.Provinces[4], District: this.Districts[9] });
    this.Addresses.push({ AddressId: 16, DepartmentId: 3, ProvinceId: 6, DistrictId: 12, Department: this.Departments[2], Province: this.Provinces[5], District: this.Districts[11] });
    this.Addresses.push({ AddressId: 17, DepartmentId: 4, ProvinceId: 7, DistrictId: 14, Department: this.Departments[3], Province: this.Provinces[6], District: this.Districts[13] });
    this.Addresses.push({ AddressId: 18, DepartmentId: 4, ProvinceId: 8, DistrictId: 16, Department: this.Departments[3], Province: this.Provinces[7], District: this.Districts[15] });
    this.Addresses.push({ AddressId: 19, DepartmentId: 5, ProvinceId: 9, DistrictId: 18, Department: this.Departments[4], Province: this.Provinces[8], District: this.Districts[17] });
    this.Addresses.push({ AddressId: 20, DepartmentId: 5, ProvinceId: 10, DistrictId: 20, Department: this.Departments[4], Province: this.Provinces[9], District: this.Districts[19] });
  }
  
  private initUser() {
    this.Users.push({
      Id: "0d5f0792-b5b3-4410-946d-6b2a2fe75d92",
      PersonId:1,
      Title: "Ing.",
      FirstName: "Erick",
      LastName: "Aróstegui",
      SurName: "Cunza",
      FullName: "Erick Aróstegui Cunza",
      IdentificationNumber: "12345678",
      UserName: "Administrator",
      Email: "Scorpius86@gmail.com",
      Phone: "99999999",
      Address: this.Addresses[0],
      Password: "P@ssword1234",
      Roles: [this.Roles[0], this.Roles[1], this.Roles[3]]      
    });
    this.Users.push({
      Id: "1d548285-1529-43ca-9aa0-bcd9a37f28d8",
      PersonId:2,
      Title: "",
      FirstName: "Juan",
      LastName: "Perez",
      SurName: "Lopez",
      FullName: "Juan Perez Lopez",
      IdentificationNumber: "12345671",
      UserName: "juan",
      Email: "juan@tod.local",
      Phone: "1111111111",
      Address: this.Addresses[1],
      Password: "P@ssword1234",
      Roles: [this.Roles[2], this.Roles[3]]      
    });
    this.Users.push({
      Id: "b5ce3be5-0adc-49b3-a04e-022a983bad47",
      PersonId:3,
      Title: "",
      FirstName: "Jose",
      LastName: "Rodriguez",
      SurName: "Fernandez",
      FullName: "Jose Rodriguez Fernandez",
      IdentificationNumber: "12345672",
      UserName: "jose",
      Email: "jose@todo.local",
      Phone: "22222222",
      Address: this.Addresses[2],
      Password: "P@ssword1234",
      Roles: [this.Roles[2], this.Roles[3]]
    });
    this.Users.push({
      Id: "20e8adce-692e-449d-9045-7689327abb06",
      PersonId:4,
      Title: "",
      FirstName: "Scarlett",
      LastName: "Johansson",
      SurName: "",
      FullName: "Scarlett Johansson",
      IdentificationNumber: "12345673",
      UserName: "scarlett",
      Email: "scarlett@todo.local",
      Phone: "33333333",
      Address: this.Addresses[3],
      Password: "P@ssword1234",
      Roles: [this.Roles[2], this.Roles[3]]
    });
    this.Users.push({
      Id: "3b149e7b-9119-444e-a6df-9af052483963",
      PersonId:5,
      Title: "",
      FirstName: "Destiny",
      LastName: "Hope",
      SurName: "Cyrus",
      FullName: "Destiny Hope Cyrus",
      IdentificationNumber: "12345674",
      UserName: "destiny",
      Email: "destiny@todo.local",
      Phone: "444444444",
      Address: this.Addresses[4],
      Password: "P@ssword1234",
      Roles: [this.Roles[2], this.Roles[3]]
    });
  }

  private initInstructors() {
    let person: Person;
    let user: User;
    let instructor: Instructor;

    person = {      
      PersonId:6,
      Title: "Ing.",
      FirstName: "Bill",
      LastName: "Gates",
      SurName: "",
      FullName: "Bill Gates",
      IdentificationNumber: "87654321",      
      Email: "bill@todo.local",
      Phone: "111111111",
      Address: this.Addresses[5]      
    };

    user = new User(person);
    user.UserName = "bill";
    user.Roles = [this.Roles[1]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    instructor = new Instructor(person);
    instructor.Category = this.Categories[4];
    this.Instructors.push(instructor);
       

    person = {
      PersonId: 7,
      Title: "Ing.",      
      FirstName: "Jeff",
      LastName: "Bezos",
      SurName: "",
      FullName: "Jeff Bezos",
      IdentificationNumber: "87654322",      
      Email: "jeff@todo.local",
      Phone: "22222222",
      Address: this.Addresses[6]      
    };

    user = new User(person);
    user.UserName = "jeff";
    user.Roles = [this.Roles[1]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    instructor = new Instructor(person);
    instructor.Category = this.Categories[0];
    this.Instructors.push(instructor);

    person = {
      PersonId: 8,
      Title: "Ing.",      
      FirstName: "Alexander",
      LastName: "Graham",
      SurName: "Bell",
      FullName: "Alexander Graham Bell",
      IdentificationNumber: "87654323",      
      Email: "alexander@todo.local",
      Phone: "33333333",
      Address: this.Addresses[7]      
    };

    user = new User(person);
    user.UserName = "alexander";
    user.Roles = [this.Roles[1]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    instructor = new Instructor(person);
    instructor.Category = this.Categories[1];
    this.Instructors.push(instructor);

    person = {
      PersonId: 9,
      Title: "Ing.",
      FirstName: "Edgard",
      LastName: "Frank",
      SurName: "Codd",
      FullName: "Edgar Frank Codd",
      IdentificationNumber: "87654324",      
      Email: "edgard@todo.local",
      Phone: "44444444",
      Address: this.Addresses[8]      
    };

    user = new User(person);
    user.UserName = "edgard";
    user.Roles = [this.Roles[1]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    instructor = new Instructor(person);
    instructor.Category = this.Categories[2];
    this.Instructors.push(instructor);

    person = {
      PersonId: 10,
      Title: "Ing.",
      FirstName: "James",
      LastName: "Gosling",
      SurName: "",
      FullName: "James Gosling",
      IdentificationNumber: "87654325",      
      Email: "james@todo.local",
      Phone: "555555555",
      Address: this.Addresses[9]      
    };

    user = new User(person);
    user.UserName = "james";
    user.Roles = [this.Roles[1]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    instructor = new Instructor(person);
    instructor.Category = this.Categories[3];
    this.Instructors.push(instructor);

  }

  private initWorkshops() {
    let cover = this._dummyImagesService.Cover;
    let agenda = this._dummyImagesService.Agenda;

    this.Workshops.push({
      WorkshopId: 1,
      WorkshopStateId: this.WorkshopStates[0].WorkshopStateId,
      InstructorId: this.Instructors[0].PersonId,
      Title: "EC2 and VPC network and infrastructure management",
      Description: "EC2 and VPC network and infrastructure management",
      CategoryId: this.Categories[0].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 16, minutes: 0 },
      StartTimeString: "16:00",
      Quantity: 5,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[0],
      Instructor: this.Instructors[0],
      Category:this.Categories[0]
    });
    this.Workshops.push({
      WorkshopId: 2,
      WorkshopStateId: this.WorkshopStates[1].WorkshopStateId,
      InstructorId: this.Instructors[1].PersonId,
      Title: 'Generando reportes con "Extend Reports"',
      Description: 'Generando reportes con "Extend Reports"',
      CategoryId: this.Categories[1].CategoryId,
      StartDate: new Date(),
      StartTimeString: "17:00",
      StartTime: { hours: 17, minutes: 0 },
      Quantity: 10,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[1],
      Instructor: this.Instructors[1],
      Category: this.Categories[1]
    });
    this.Workshops.push({
      WorkshopId: 3,
      WorkshopStateId: this.WorkshopStates[2].WorkshopStateId,
      InstructorId: this.Instructors[2].PersonId,
      Title: 'Simplificación de tareas de administración en Oracle 12c, 18c y 19c',
      Description: 'Simplificación de tareas de administración en Oracle 12c, 18c y 19c',
      CategoryId: this.Categories[2].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 18, minutes: 0 },
      StartTimeString: "18:00",
      Quantity: 15,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[2],
      Instructor: this.Instructors[2],
      Category: this.Categories[2]
    });
    this.Workshops.push({
      WorkshopId: 4,
      WorkshopStateId: this.WorkshopStates[3].WorkshopStateId,
      InstructorId: this.Instructors[3].PersonId,
      Title: 'Programacion funcional en Java',
      Description: 'Programacion funcional en Java',
      CategoryId: this.Categories[3].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 19, minutes: 0 },
      StartTimeString: "19:00",
      Quantity: 25,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[3],
      Instructor: this.Instructors[3],
      Category: this.Categories[3]
    });
    this.Workshops.push({
      WorkshopId: 5,
      WorkshopStateId: this.WorkshopStates[0].WorkshopStateId,
      InstructorId: this.Instructors[4].PersonId,
      Title: 'Angular interceptores',
      Description: 'Angular interceptores',
      CategoryId: this.Categories[4].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 19, minutes: 0 },
      StartTimeString: "19:00",
      Quantity: 25,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[0],
      Instructor: this.Instructors[4],
      Category: this.Categories[4]
    });
    this.Workshops.push({
      WorkshopId: 6,
      WorkshopStateId: this.WorkshopStates[0].WorkshopStateId,
      InstructorId: this.Instructors[0].PersonId,
      Title: 'Gestión de identidad y Accesos y creación de Buckets con  IAM y S3',
      Description: 'Gestión de identidad y Accesos y creación de Buckets con  IAM y S3',
      CategoryId: this.Categories[0].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 19, minutes: 0 },
      StartTimeString: "19:00",
      Quantity: 30,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[0],
      Instructor: this.Instructors[0],
      Category: this.Categories[0]
    });
    this.Workshops.push({
      WorkshopId: 7,
      WorkshopStateId: this.WorkshopStates[1].WorkshopStateId,
      InstructorId: this.Instructors[1].PersonId,
      Title: 'Angular Http',
      Description: 'Angular Http',
      CategoryId: this.Categories[4].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 19, minutes: 0 },
      StartTimeString: "19:00",
      Quantity: 10,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[1],
      Instructor: this.Instructors[1],
      Category: this.Categories[4]
    });
    this.Workshops.push({
      WorkshopId: 8,
      WorkshopStateId: this.WorkshopStates[2].WorkshopStateId,
      InstructorId: this.Instructors[2].PersonId,
      Title: 'Automatización de pruebas en aplicaciones web con selenium ',
      Description: 'Automatización de pruebas en aplicaciones web con selenium ',
      CategoryId: this.Categories[1].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 19, minutes: 0 },
      StartTimeString: "19:00",
      Quantity: 20,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[1],
      Instructor: this.Instructors[2],
      Category: this.Categories[1]
    });
    this.Workshops.push({
      WorkshopId: 9,
      WorkshopStateId: this.WorkshopStates[3].WorkshopStateId,
      InstructorId: this.Instructors[3].PersonId,
      Title: 'Aplicaciones con Spring Security',
      Description: 'Aplicaciones con Spring Security',
      CategoryId: this.Categories[3].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 19, minutes: 0 },
      StartTimeString: "19:00",
      Quantity: 5,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[3],
      Instructor: this.Instructors[3],
      Category: this.Categories[3]
    });
    this.Workshops.push({
      WorkshopId: 10,
      WorkshopStateId: this.WorkshopStates[3].WorkshopStateId,
      InstructorId: this.Instructors[4].PersonId,
      Title: 'Azure Spring Boot',
      Description: 'Azure Spring Boot',
      CategoryId: this.Categories[6].CategoryId,
      StartDate: new Date(),
      StartTime: { hours: 19, minutes: 0 },
      StartTimeString: "19:00",
      Quantity: 35,
      CoverFileDataId: cover.FileDataId,
      AgendaFileDataId: agenda.FileDataId,
      CoverFileData: cover,
      AgendaFileData: agenda,
      WorkshopState: this.WorkshopStates[3],
      Instructor: this.Instructors[4],
      Category: this.Categories[6]
    });
  }

  private initEnrollmentStates() {
    this.EnrollmentStates.push({ EnrollmentStateId: 1, Description: "Enrolled" });
    this.EnrollmentStates.push({ EnrollmentStateId: 2, Description: "Attend" });
    this.EnrollmentStates.push({ EnrollmentStateId: 3, Description: "Canceled" });    
  }

  private initEnrollees(){
    let person: Person;
    let user: User;
    let enrolled: Enrolled;

    person = {
      PersonId: 11,
      Title: "Sr.",
      FirstName: "Igor",
      LastName: "Villar",
      SurName: "",
      FullName: "Igor Villar",
      IdentificationNumber: "11111111",
      Email: "igor@todo.local",
      Phone: "111111111",
      Address: this.Addresses[10]
    };

    user = new User(person);
    user.UserName = "igor";
    user.Roles = [this.Roles[2]];    
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 12,
      Title: "Sr.",
      FirstName: "Zakaria",
      LastName: "Jerez",
      SurName: "",
      FullName: "Zakaria Jerez",
      IdentificationNumber: "11111112",
      Email: "zakaria@todo.local",
      Phone: "111111112",
      Address: this.Addresses[11]
    };

    user = new User(person);
    user.UserName = "zakaria";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 13,
      Title: "Sr.",
      FirstName: "Dionisio",
      LastName: "Aragon",
      SurName: "",
      FullName: "Dionisio Aragon",
      IdentificationNumber: "11111113",
      Email: "dionisio@todo.local",
      Phone: "111111113",
      Address: this.Addresses[12]
    };

    user = new User(person);
    user.UserName = "dionisio";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 14,
      Title: "Sr.",
      FirstName: "Hassan",
      LastName: "Carrillo",
      SurName: "",
      FullName: "Hassan Carrillo",
      IdentificationNumber: "11111114",
      Email: "hassan@todo.local",
      Phone: "111111114",
      Address: this.Addresses[13]
    };

    user = new User(person);
    user.UserName = "hassan";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 15,
      Title: "Sr.",
      FirstName: "Esteban",
      LastName: "Francisco",
      SurName: "Pacheco",
      FullName: "Esteban Francisco Pacheco",
      IdentificationNumber: "11111115",
      Email: "esteban@todo.local",
      Phone: "111111115",
      Address: this.Addresses[14]
    };

    user = new User(person);
    user.UserName = "esteban";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 16,
      Title: "Srta.",
      FirstName: "Aina",
      LastName: "Oliver",
      SurName: "",
      FullName: "Aina Oliver",
      IdentificationNumber: "11111116",
      Email: "aina@todo.local",
      Phone: "111111116",
      Address: this.Addresses[15]
    };

    user = new User(person);
    user.UserName = "aina";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 17,
      Title: "Srta.",
      FirstName: "Jesusa",
      LastName: "Giraldo",
      SurName: "",
      FullName: "Jesusa Giraldo",
      IdentificationNumber: "11111117",
      Email: "jesusa@todo.local",
      Phone: "111111117",
      Address: this.Addresses[16]
    };

    user = new User(person);
    user.UserName = "jesusa";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 18,
      Title: "Srta.",
      FirstName: "Elisabeth",
      LastName: "Pico",
      SurName: "",
      FullName: "Elisabeth Pico",
      IdentificationNumber: "11111118",
      Email: "elisabeth@todo.local",
      Phone: "111111118",
      Address: this.Addresses[17]
    };

    user = new User(person);
    user.UserName = "elisabeth";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 19,
      Title: "Srta.",
      FirstName: "Leticia",
      LastName: "Escudero",
      SurName: "",
      FullName: "Leticia Escudero",
      IdentificationNumber: "11111119",
      Email: "leticia@todo.local",
      Phone: "111111119",
      Address: this.Addresses[18]
    };

    user = new User(person);
    user.UserName = "leticia";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);

    person = {
      PersonId: 20,
      Title: "Sr.",
      FirstName: "Maite",
      LastName: "Riquelme",
      SurName: "",
      FullName: "Maite Riquelme",
      IdentificationNumber: "111111120",
      Email: "maite@todo.local",
      Phone: "111111120",
      Address: this.Addresses[19]
    };

    user = new User(person);
    user.UserName = "maite";
    user.Roles = [this.Roles[2]];
    user.Password = "P@ssword1234";
    this.Users.push(user);

    enrolled = new Enrolled(person);    
    this.Enrollees.push(enrolled);
  }

  private initEnrollments() {
    this.Enrollments.push({
      EnrollmentId: 1,
      EnrolledId: this.Enrollees[0].PersonId,
      Enrolled: this.Enrollees[0],
      WorkshopId: 1,
      Workshop: this.Workshops[0],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[0].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[0],      
    });
    this.Enrollments.push({
      EnrollmentId: 2,
      EnrolledId: this.Enrollees[1].PersonId,
      Enrolled: this.Enrollees[1],
      WorkshopId: 2,
      Workshop: this.Workshops[1],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[1].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[1]
    });
    this.Enrollments.push({
      EnrollmentId: 3,
      EnrolledId: this.Enrollees[2].PersonId,
      Enrolled: this.Enrollees[2],
      WorkshopId: 3,
      Workshop: this.Workshops[2],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[2].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[2]
    });
    this.Enrollments.push({
      EnrollmentId: 4,
      EnrolledId: this.Enrollees[3].PersonId,
      Enrolled: this.Enrollees[3],
      WorkshopId: 4,
      Workshop: this.Workshops[3],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[0].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[0]
    });
    this.Enrollments.push({
      EnrollmentId: 5,
      EnrolledId: this.Enrollees[4].PersonId,
      Enrolled: this.Enrollees[4],
      WorkshopId: 5,
      Workshop: this.Workshops[4],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[1].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[1]
    });
    this.Enrollments.push({
      EnrollmentId: 6,
      EnrolledId: this.Enrollees[5].PersonId,
      Enrolled: this.Enrollees[5],
      WorkshopId: 6,
      Workshop: this.Workshops[5],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[2].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[2]
    });
    this.Enrollments.push({
      EnrollmentId: 7,
      EnrolledId: this.Enrollees[6].PersonId,
      Enrolled: this.Enrollees[6],
      WorkshopId: 7,
      Workshop: this.Workshops[6],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[0].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[0]
    });
    this.Enrollments.push({
      EnrollmentId: 8,
      EnrolledId: this.Enrollees[7].PersonId,
      Enrolled: this.Enrollees[7],
      WorkshopId: 8,
      Workshop: this.Workshops[7],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[1].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[1]
    });
    this.Enrollments.push({
      EnrollmentId: 9,
      EnrolledId: this.Enrollees[8].PersonId,
      Enrolled: this.Enrollees[8],
      WorkshopId: 9,
      Workshop: this.Workshops[8],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[2].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[2]
    });
    this.Enrollments.push({
      EnrollmentId: 10,
      EnrolledId: this.Enrollees[9].PersonId,
      Enrolled: this.Enrollees[9],
      WorkshopId: 10,
      Workshop: this.Workshops[9],
      EnrollmentDate: new Date(),
      EnrollmentStateId: this.EnrollmentStates[0].EnrollmentStateId,
      EnrollmentState: this.EnrollmentStates[0]
    });
  }
}
