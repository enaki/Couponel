import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {ProfileInfoModel} from '../models/profile-info.model';
import {UserService} from '../../shared/services';
import {UpdateProfileInfoModel} from '../models/update-profile-info.model';

@Injectable({
  providedIn: 'root',
})
export class ProfileInfoService {
  public endpoint = 'https://localhost:5001/api/users';
  private httpOptions: unknown;

  constructor(private readonly httpClient: HttpClient, private readonly userService: UserService) {
    this.userService.token.subscribe(() => {
      this.httpOptions = this.userService.getHttpOptions();
    });
  }

  public getProfileInfo(userId: string): Observable<ProfileInfoModel> {
    return this.httpClient.get<ProfileInfoModel>(`${this.endpoint}/${userId}`, this.httpOptions);
  }

  public updateProfileInfo(profile: UpdateProfileInfoModel): Observable<ProfileInfoModel> {
    console.log(profile);
    return this.httpClient.patch<ProfileInfoModel>(`${this.endpoint}`, profile, this.httpOptions);
  }
}
