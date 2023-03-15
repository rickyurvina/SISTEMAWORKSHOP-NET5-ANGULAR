import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Department } from "../../../models/department";
import { District } from "../../../models/district";
import { Province } from "../../../models/province";
import { ApplicationStateService } from "../../settings/application-state.service";

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  private DepartmentsUrl = "https://localhost:44313/api/Departments";
  private ProvincesUrl = "https://localhost:44313/api/Departments/{departmentId}/Provinces";
  private DistrictsUrl = "https://localhost:44313/api/Provinces/{provinceId}/Districts"; 

  constructor(
    private _httpClient: HttpClient,    
    private _applicationSatateService: ApplicationStateService
  ) { }

  listDepartments(): Observable<Array<Department>> {
    const path = `/`;
    const url = `${this.DepartmentsUrl}${path}`;
    return this._httpClient.get<Array<Department>>(url);
  }

  listProvincesByDepartmentId(departmentId: number): Observable<Array<Province>> {
    const path = `/`;
    const urlBase = `${this.ProvincesUrl.replace('{departmentId}', departmentId.toString())}`;
    const url = `${urlBase}${path}`;
    return this._httpClient.get<Array<Province>>(url);
  }

  listDistrictsByProvinceId(provinceId: number): Observable<Array<District>> {
    const path = `/`;
    const urlBase = `${this.DistrictsUrl.replace('{provinceId}', provinceId.toString())}`;
    const url = `${urlBase}${path}`;
    return this._httpClient.get<Array<District>>(url);
  }
}
