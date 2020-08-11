import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {UniversityModel} from '../models/university.model';
@Injectable({
  providedIn: 'root',
})
export class UniversityService{
  private endpoint = 'https://localhost:5001/api/universities';
  constructor(private readonly http: HttpClient) {
  }

  public getAll(): Observable<UniversityModel[]> {
    return this.http.get<UniversityModel[]>(`${this.endpoint}`);
  }
}
