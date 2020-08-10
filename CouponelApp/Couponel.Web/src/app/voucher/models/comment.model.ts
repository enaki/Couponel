import {CommentUserModel} from './comment.user.model';

export type CommentModel = {
  userId: string;
  id: string;
  content: string;
  user: CommentUserModel;
};
