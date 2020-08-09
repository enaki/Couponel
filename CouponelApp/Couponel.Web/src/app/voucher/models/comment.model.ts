import {UserModel} from './user.model';

export type CommentModel = {
  userId: string;
  id: string;
  content: string;
  user: UserModel;
};
