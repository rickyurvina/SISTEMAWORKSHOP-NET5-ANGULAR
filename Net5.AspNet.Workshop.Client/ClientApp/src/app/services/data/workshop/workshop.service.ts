import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators';
import { Category } from '../../../models/category';
import { Enrollment } from '../../../models/enrollment';
import { EnrollmentState } from '../../../models/enrollment-state';
import { EnrollmentStateEnum } from '../../../models/enums/enrollment-state-enum';
import { Instructor } from '../../../models/instructor';
import { Workshop } from '../../../models/workshop';
import { WorkshopState } from '../../../models/workshop-state';
import { ApplicationStateService } from '../../settings/application-state.service';
import { DummyDataService } from '../dummy-data.service';
import { EnrolledFilter } from './enrolled-filter';
import { EnrollmentFilter } from './enrollment-filter';
import { EnrollmentStateFilter } from './enrollment-state-filter';
import { InstructorFilter } from './instructor-filter';
import { WorkshopFilter } from './workshop-filter';

@Injectable({
  providedIn: 'root'
})
export class WorkshopService {

  private WorkshopsUrl = "https://localhost:44322/api/Workshops";
  private EnrollmentsUrl = "https://localhost:44322/api/Enrollments";
  private InstructorsUrl = "https://localhost:44322/api/Instructors";
  private CategoriesUrl = "https://localhost:44322/api/Categories";
  private WorkshopStatesUrl = "https://localhost:44322/api/WorkshopStates";
  private EnrollmentStatesUrl = "https://localhost:44322/api/EnrollmentStates";

  constructor(
    private _httpClient: HttpClient,
    private _dummyDatService: DummyDataService,
    private _applicationSatateService: ApplicationStateService    
  ) { }

  listCategories(): Observable<Array<Category>> {    
    const path = `/`;
    const url = `${this.CategoriesUrl}${path}`;
    return this._httpClient.get<Array<Category>>(url);
  }

  listWorkshopStates(): Observable<Array<WorkshopState>> {    
    const path = `/`;
    const url = `${this.WorkshopStatesUrl}${path}`;
    return this._httpClient.get<Array<WorkshopState>>(url);
  }

  listWorkshops(filter?: WorkshopFilter): Observable<Array<Workshop>> {    
    const params = Object.assign({}, filter) as any;
    if (filter) {
      if (filter.StartDate) { params.StartDate = filter.StartDate!.toISOString(); }
      if (filter.EndDate) { params.EndDate = filter.EndDate!.toISOString(); }
    }
    const path = `/`;
    const url = `${this.WorkshopsUrl}${path}`;
    return this._httpClient.get<Array<Workshop>>(url, { params: params });
  }

  getWorkshop(workshopId: number): Observable<Workshop> {    
    const path = `/${workshopId}`;
    const url = `${this.WorkshopsUrl}${path}`;
    return this._httpClient.get<Workshop>(url);    
  }

  updateWorkshop(workshop: Workshop): Observable<Workshop> {
    const path = `/${workshop.WorkshopId}`;
    const url = `${this.WorkshopsUrl}${path}`;
    return this._httpClient.put<Workshop>(url, workshop); 
  }

  insertWorkshop(workshop: Workshop): Observable<Workshop> {    
    const path = `/`;
    const url = `${this.WorkshopsUrl}${path}`;
    return this._httpClient.post<Workshop>(url, workshop);
  }

  deleteWorkshop(workshopId: number): Observable<Workshop> {
    const path = `/${workshopId}`;
    const url = `${this.WorkshopsUrl}${path}`;
    return this._httpClient.delete<Workshop>(url);
  }

  listInstructors(filter?: InstructorFilter): Observable<Array<Instructor>> {
    const params = filter as any;
    const path = `/`;
    const url = `${this.InstructorsUrl}${path}`;
    return this._httpClient.get<Array<Instructor>>(url, { params: params });
  }

  listEnrollmentStates(filter: EnrollmentStateFilter): Observable<Array<EnrollmentState>> {
    const params = filter as any;
    const path = `/`;
    const url = `${this.EnrollmentStatesUrl}${path}`;
    return this._httpClient.get<Array<EnrollmentState>>(url, { params: params });
  }

  switchEnrollmentState(enrollment: Enrollment): Observable<Enrollment> {
    const enrollmentStateId = (enrollment.EnrollmentStateId == EnrollmentStateEnum.Attend) ? EnrollmentStateEnum.Canceled : EnrollmentStateEnum.Attend;
    const changeEnrollmentStatesFilter = { enrollmentIds: [enrollment.EnrollmentId], enrollmentStateId: enrollmentStateId };
    const path = `/ChangeEnrollmentStates`;
    const url = `${this.EnrollmentsUrl}${path}`;
    return this._httpClient.post<Array<Enrollment>>(url, changeEnrollmentStatesFilter).pipe(
      map(enrollments => enrollments[0])      
    );
  }

  changeEnrollmentStates(enrollmentIds: Array<number>, enrollmentStateId: EnrollmentStateEnum): Observable<Array<Enrollment>> {    
    const changeEnrollmentStatesFilter = { enrollmentIds: enrollmentIds, enrollmentStateId: enrollmentStateId };
    const path = `/ChangeEnrollmentStates`;
    const url = `${this.EnrollmentsUrl}${path}`;
    return this._httpClient.post<Array<Enrollment>>(url, changeEnrollmentStatesFilter);
  }

  listEnrollmentsAttendOrCanceled(filter: EnrollmentFilter): Observable<Array<Enrollment>> {    
    const params = Object.assign({}, filter) as any;
    if (filter.EnrollmentStatesIds.length == 0) { params.EnrollmentStatesIds = [EnrollmentStateEnum.Attend, EnrollmentStateEnum.Canceled]; }    
    if (filter.StartDate) { params.StartDate = filter.StartDate!.toISOString(); }
    if (filter.EndDate) { params.EndDate = filter.EndDate!.toISOString(); }

    const path = `/`;
    const url = `${this.EnrollmentsUrl}${path}`;
    return this._httpClient.get<Array<Enrollment>>(url, { params: params });
  }

  listEnrollmentsEnrolled(filter: EnrollmentFilter): Observable<Array<Enrollment>> {    
    const params = Object.assign({}, filter) as any;
    params.EnrollmentStatesIds = [EnrollmentStateEnum.Enrolled];    
    const path = `/`;
    const url = `${this.EnrollmentsUrl}${path}`;
    return this._httpClient.get<Array<Enrollment>>(url, { params: params });
  }

  listEnrollments(filter: EnrollmentFilter): Observable<Array<Enrollment>> {
    const params = Object.assign({}, filter) as any;    
    const path = `/`;
    const url = `${this.EnrollmentsUrl}${path}`;
    return this._httpClient.get<Array<Enrollment>>(url, { params: params });
  }

  insertEnrollomnet(workshopId: number): Observable<Enrollment> {
    const enrollment = new Enrollment();
    enrollment.WorkshopId = workshopId;
    const path = `/`;
    const url = `${this.EnrollmentsUrl}${path}`;
    return this._httpClient.post<Enrollment>(url, enrollment);
  }
}
