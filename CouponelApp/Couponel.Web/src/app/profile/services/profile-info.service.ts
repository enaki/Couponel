import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProfileInfoModel } from '../models/profile-info.model';

@Injectable({
  providedIn: 'root',
})
export class ProfileInfoService {
  public endpoint =
        'https://localhost:5001/api/users';
        private httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
            Authorization: `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
          })
        };
  constructor(private readonly httpClient: HttpClient) {}

  public getProfilInfo(userId: string): Observable<ProfileInfoModel> {
    return this.httpClient.get<ProfileInfoModel>(`${this.endpoint}/${userId}`,this.httpOptions);

  }
  //sa creez o noua metoda de update care sa apeleze endpointu ptr a updata
 /* public updateProfileInfo(userId: string): Observable<ProfileInfoModel> {
    return this.httpClient.get<ProfileInfoModel>(`${this.endpoint}/${userId}`,this.httpOptions);

  }*/
}
