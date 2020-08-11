import {FacultyModel} from './faculty.model';

export type UniversityModel = {
  id: string;
  name: string;
  faculties: FacultyModel[];
};
